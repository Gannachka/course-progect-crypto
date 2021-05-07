using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace CourseProgect.Algoritms
{
    public class RSAClass
    {
        static RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
        static UnicodeEncoding Encoding = new UnicodeEncoding();
        static byte[] plaintext;
        static byte[] encryptedtext;

        public static string EncryptMessage(string inputValue)
        {
            plaintext = Encoding.GetBytes(inputValue);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            return Encoding.GetString(encryptedtext);
        }

        public static string DecryptMessage()
        {
            byte[] decryptedtex = Decryption(encryptedtext, RSA.ExportParameters(true), false);
            return Encoding.GetString(decryptedtex);
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {

            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
