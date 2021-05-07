using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace CourseProgect.Algoritms.diffiie_helman
{
    public class DiffieHellmanEncryption
    {
        public static byte[] encryptedMessage;
        public static byte[] senderKey;
        public static byte[] IV;
        public static byte[] Person2PublicKey;
        private static byte[] Key;

        static UnicodeEncoding Encoder = new UnicodeEncoding();
        private Aes aes = new AesCryptoServiceProvider();


        public static byte[] Person1PublicKey;

        public  string Encrypt(string secretMessage)
        {
            using (ECDiffieHellmanCng ecd = new ECDiffieHellmanCng())
            {
                ecd.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                ecd.HashAlgorithm = CngAlgorithm.Sha256;
                Person1PublicKey = ecd.PublicKey.ToByteArray();

                CngKey k = CngKey.Import(Person1PublicKey, CngKeyBlobFormat.EccPublicBlob);
                senderKey = ecd.DeriveKeyMaterial(CngKey.Import(Person1PublicKey, CngKeyBlobFormat.EccPublicBlob));
               
            }
                // Encrypt the message
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] plainTextMessage = Encoding.UTF8.GetBytes(secretMessage);
                cs.Write(plainTextMessage, 0, plainTextMessage.Length);
                cs.Close();
                encryptedMessage = ms.ToArray();
            }


            return Convert.ToBase64String(encryptedMessage);
        }

        public string Decrypt()
        {
            using (ECDiffieHellmanCng ecd = new ECDiffieHellmanCng())
            {
                ecd.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                ecd.HashAlgorithm = CngAlgorithm.Sha256;
                Person2PublicKey = ecd.PublicKey.ToByteArray();
                Key = ecd.DeriveKeyMaterial(CngKey.Import(Person1PublicKey, CngKeyBlobFormat.EccPublicBlob));

            }

                // Decrypt and show the message
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                cs.Close();

                string message = Encoding.UTF8.GetString(ms.ToArray());
                return message;
            }
        }
    }
}
