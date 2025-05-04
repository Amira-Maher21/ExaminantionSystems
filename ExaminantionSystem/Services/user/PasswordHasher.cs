using System.Security.Cryptography;
using System.Text;

namespace ExaminantionSystem.Services.user
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            // استخدام SHA256 أو الأفضل استخدام BCrypt لاحقاً
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string hashed)
        {
            return Hash(password) == hashed;
        }
    }

}
