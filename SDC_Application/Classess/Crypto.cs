using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SDC_Application.Classess
{
   static class Crypto
    {
        #region Funtion Get Encrypted Text
        /// <summary>
        /// the function getEncryptedCode used for getting palin text password from encrypted password.
        /// </summary>
        /// <param name="inputString">Encrypted Password</param>
        /// <returns></returns>

        private static String key = "slmi-1hn8-sqoy22";

        public static string getEncryptedCode(string inputString)
        {
            inputString.Replace("'", "’");
            int index = 0;
            int hashLength = 0;
            byte[] tmpSource = Encoding.ASCII.GetBytes(inputString);
            byte[] tmpHash = new SHA512Managed().ComputeHash(tmpSource);
            hashLength = tmpHash.Length;
            StringBuilder outputString = new StringBuilder(hashLength);
            for (index = 0; index < hashLength; index++)
            {
                outputString.Append(tmpHash[index].ToString("X2"));
            }
            return outputString.ToString();
        }
        public static string Encrypt(string input)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }  

        #endregion
    }
}
