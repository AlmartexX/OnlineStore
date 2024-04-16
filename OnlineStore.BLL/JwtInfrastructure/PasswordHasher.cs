using System.Security.Cryptography;
using System.Text;

namespace OnlineStore.BLL.JwtInfrastructure
{
    internal class PasswordHasher
    {
        public static string GetHash(string password)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
        public static bool Verify(string userPassword, string inputPassword)
        {
            if (GetHash(userPassword) == GetHash(inputPassword))
            {
                return true;
            }
            else { return false; }
        }
    }
}
