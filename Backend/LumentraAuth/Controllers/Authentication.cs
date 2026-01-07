using Google.Cloud.Firestore;
using LumentraAuth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LumentraAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly FirestoreDb _db;
        private readonly IConfiguration _configuration;

        public AuthenticationController(FirestoreDb db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            var jwtConfig = _configuration.GetSection("Jwt");
            var keyString = jwtConfig["Key"];

            if (string.IsNullOrEmpty(keyString) || keyString.Length < 32)
            {
                throw new InvalidOperationException("JWT Key must be at least 256 bits (32 characters).");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.userId),
                new Claim(JwtRegisteredClaimNames.Email, user.userEmail),
                new Claim(ClaimTypes.Role, user.userRole.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtConfig["ExpiresInMinutes"] ?? "60")),
                Issuer = jwtConfig["Issuer"],
                Audience = jwtConfig["Audience"]
            };

            var handler = new JsonWebTokenHandler();

            return handler.CreateToken(tokenDescriptor);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserSignUpDto signupDto)
        {
            if (string.IsNullOrEmpty(signupDto.userEmail) ||
                string.IsNullOrEmpty(signupDto.userPassword) ||
                string.IsNullOrEmpty(signupDto.userName))
            {
                return BadRequest(new { message = "All fields are required" });
            }

            var usersRef = _db.Collection("Users");
            var query = usersRef.WhereEqualTo("userEmail", signupDto.userEmail);
            var querySnapshot = await query.GetSnapshotAsync();

            if (querySnapshot.Count > 0)
                return BadRequest(new { message = "Email already exists" });

            var encryptedPassword = HashPassword(signupDto.userPassword);

            var userDocRef = usersRef.Document(); 
            var user = new User
            {
                userId = userDocRef.Id,
                userEmail = signupDto.userEmail,
                userEncryptedPassword = encryptedPassword,
                userName = signupDto.userName,
                userRole = UserRole.User.ToString()
            };

            await userDocRef.SetAsync(user);


            return Ok(new { message = "User created successfully!" });
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.userEmail) ||
                string.IsNullOrEmpty(loginDto.userPassword))
            {
                return BadRequest(new { message = "Email and password are required" });
            }

            var usersRef = _db.Collection("Users");
            var query = usersRef.WhereEqualTo("userEmail", loginDto.userEmail);
            var querySnapshot = await query.GetSnapshotAsync();
            if (querySnapshot.Count == 0)
                return Unauthorized(new { message = "Invalid email or password" });
            var userDoc = querySnapshot.Documents[0];
            var user = userDoc.ConvertTo<User>();
            var hashedInputPassword = HashPassword(loginDto.userPassword);
            if (user.userEncryptedPassword != hashedInputPassword)
                return Unauthorized(new { message = "Invalid email or password" });

            var token = GenerateJwtToken(user);
            return Ok(new { 
                message = "Login successful!",
                token = token});
        }

        [HttpPost("authorize")]
        public IActionResult Authorize([FromBody] TokenDto tokenDto)
        {
            if (string.IsNullOrEmpty(tokenDto.Token))
                return BadRequest(new { message = "Token is required" });

            var jwtConfig = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]));

            var tokenHandler = new JsonWebTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false, 
                ValidateLifetime = true,
                IssuerSigningKey = key
            };

            try
            {
                var result = tokenHandler.ValidateToken(tokenDto.Token, validationParameters);

                if (result.IsValid)
                {
                    return Ok(new { message = "Token is valid" });
                }
                else
                {
                    return Unauthorized(new { message = "Invalid token" });
                }
            }
            catch
            {
                return Unauthorized(new { message = "Invalid token" });
            }
        }

    }
}
