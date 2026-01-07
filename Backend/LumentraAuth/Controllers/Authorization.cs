using FirebaseAdmin.Auth.Hash;
using Google.Cloud.Firestore;
using LumentraAuth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace LumentraAuth.Controllers
{
    public class AuthorizationController : ControllerBase
    {
        private readonly FirestoreDb _db;
        private readonly IConfiguration _configuration;

        public AuthorizationController(FirestoreDb db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        




    }
}
