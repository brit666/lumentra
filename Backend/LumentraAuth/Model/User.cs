using Google.Cloud.Firestore;

namespace LumentraAuth.Model
{
    public enum UserRole
    {
        Admin,
        User,
        Creator
    }

    [FirestoreData]
    public class User
    {
        public User() { }

        [FirestoreProperty]
        public string userId { get; set; }
        [FirestoreProperty]
        public string userEmail { get; set; }
        [FirestoreProperty]
        public string userEncryptedPassword { get; set; }
        [FirestoreProperty]
        public string userName { get; set; }
        [FirestoreProperty]
        public String userRole { get; set; }
    }
}
