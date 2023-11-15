using System.Security.Cryptography;
using System.Text;

namespace ShopAPI2.Services
{
    public static class PasswordHash
    {
        public static string hashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] passwordByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            var sb = new StringBuilder();

            for (int i = 0; i < passwordByte.Length; i++)
            {
                sb.Append(passwordByte[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static bool checkPassword(string withSHA256, string withoutSHA256)
        {
            if (hashPassword(withoutSHA256) == withSHA256)
            {
                return true;
            }
            return false;
        }
    }
}
