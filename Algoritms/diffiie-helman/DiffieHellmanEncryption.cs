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


        public static byte[] Person1PublicKey;

        private static void Helman()
        {
            //Console.Write("Plase Enter Message to Encrypt : ");
            //string text = Convert.ToString(Console.ReadLine());
            //Console.WriteLine("----------------------------------");

            //using (ECDiffieHellmanCng ecd = new ECDiffieHellmanCng())
            //{
            //    ecd.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            //    ecd.HashAlgorithm = CngAlgorithm.Sha256;
            //    Person1PublicKey = ecd.PublicKey.ToByteArray();


            //    CngKey k = CngKey.Import(Person2PublicKey, CngKeyBlobFormat.EccPublicBlob);
            //    byte[] senderKey = ecd.DeriveKeyMaterial(CngKey.Import(Person2PublicKey, CngKeyBlobFormat.EccPublicBlob));
            //    Encrypt(senderKey, text, out byte[] encryptedMessage, out byte[] IV);
            //    Receive(encryptedMessage, IV);

            //}
        }

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
            
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = senderKey;
                IV = aes.IV;

                // Encrypt the message
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plainTextMessage = Encoding.UTF8.GetBytes(secretMessage);
                    cs.Write(plainTextMessage, 0, plainTextMessage.Length);
                    cs.Close();
                    encryptedMessage = ms.ToArray();
                }
            }


            return Convert.ToBase64String(encryptedMessage);
        }
        public  string Decrypt()
        {
            using (ECDiffieHellmanCng ecd = new ECDiffieHellmanCng())
            {
                ecd.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                ecd.HashAlgorithm = CngAlgorithm.Sha256;
                Person2PublicKey = ecd.PublicKey.ToByteArray();
                Key = ecd.DeriveKeyMaterial(CngKey.Import(Person1PublicKey, CngKeyBlobFormat.EccPublicBlob));

            }

            Console.Write("Encrypted Version : ");

            foreach (byte b in Key)
            {
                Console.Write($"{b}, ");

            }
            Console.WriteLine("Converting ... ");
            Console.WriteLine("----------------------------------");

            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = Key;
                aes.IV = IV;

                // Decrypt and show the message
                using (MemoryStream ms = new MemoryStream())
                {
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
    }


}
