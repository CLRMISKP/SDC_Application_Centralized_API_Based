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

        #endregion
    }
}
