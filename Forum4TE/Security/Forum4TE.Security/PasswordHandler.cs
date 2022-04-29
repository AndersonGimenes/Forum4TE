using System.Security.Cryptography;
using System.Text;

namespace Forum4TE.Security
{
    public static class PasswordHandler
    {
        public static string GeneratePassword(string email, string password)
        {
            var sb = new StringBuilder();

            var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{email}{password}");
            byte[] hash = md5.ComputeHash(inputBytes);

            foreach (var caracter in hash)
                sb.Append(caracter.ToString("X2"));

            return sb.ToString();
        }
    }
}
