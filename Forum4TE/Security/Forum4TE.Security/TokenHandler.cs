using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Forum4TE.Security
{
    public static class TokenHandler
    {        
        private static string _token;

        public static string EncryptToken(string token)
        {
            var resultArray = CreateMD5Object("CreateEncryptor", () => UTF8Encoding.UTF8.GetBytes(token));
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string[] DecryptToken(string token)
        {
            var resultArray = CreateMD5Object("CreateDecryptor", () => Convert.FromBase64String(token));
            return UTF8Encoding.UTF8.GetString(resultArray).Split(',');
        }

        private static byte[] CreateMD5Object(string methodName, Func<dynamic> action)
        {
            var objMD5CryptoService = new MD5CryptoServiceProvider();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            var toEncryptArray = action.Invoke();

            var securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_token));
            objMD5CryptoService.Clear();

            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService
                                            .GetType()
                                            .GetMethods()
                                            .First(x => x.Name == methodName)
                                            .Invoke(objTripleDESCryptoService, null) as ICryptoTransform;

            objTripleDESCryptoService.Clear();

            return objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        }

        public static void SetToken(this IConfiguration configuration)
        {
            _token = configuration["Security:SecurityTokenKey"];
        }
    }
}
