using AuthNote.LocalIdentity.Services.Abstractions;

namespace AuthNote.LocalIdentity.Services
{
    public class HashService : IHashService
    {
        public string HashPassword(string password)
        { 
            var hashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(password);

            return hashPassword;
        }

        public bool VerifyPassword(string password, Identity identity)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, identity.PasswordHash);
        }
    }
}
