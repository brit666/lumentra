using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

var firebaseConfig = builder.Configuration.GetSection("Firebase");
var projectId = firebaseConfig["ProjectId"];
var serviceAccountPath = firebaseConfig["ServiceAccountPath"];

if (string.IsNullOrEmpty(projectId) || string.IsNullOrEmpty(serviceAccountPath))
{
    throw new Exception("Firebase configuration is missing in appsettings.json");
}

var credential = Google.Apis.Auth.OAuth2.CredentialFactory
    .FromFile<Google.Apis.Auth.OAuth2.ServiceAccountCredential>(serviceAccountPath)
    .ToGoogleCredential();

FirebaseApp.Create(new AppOptions
{
    Credential = credential
});

var firestoreDb = new FirestoreDbBuilder
{
    ProjectId = projectId,
    Credential = credential
}.Build();

builder.Services.AddSingleton(firestoreDb);

builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
