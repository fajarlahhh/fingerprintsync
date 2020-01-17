using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Fingerprint.Helper
{
    class EncryptDecrypt
    {
        private const string passPhrase = "Rahasia";
        private const string saltValue = "Fingerprint";
        private const string hashAlgorithm = "SHA1";
        private const int passwordIterations = 3;
        private const string initVector = "@1B2c3D4e5F6g7H8";
        private const int keySize = 256;


        public string DoEncrypt(string plainText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            var keyBytes = password.GetBytes(keySize / 8);

            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };

            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            var memoryStream = new MemoryStream();

            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            var cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            var cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }

        public string DoDecrypt(string cipherText)
        {
            try
            {
                var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                var cipherTextBytes = Convert.FromBase64String(cipherText);

                var password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                var keyBytes = password.GetBytes(keySize / 8);

                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };

                var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

                var memoryStream = new MemoryStream(cipherTextBytes);

                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                var plainTextBytes = new byte[cipherTextBytes.Length];

                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                var plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

                return plainText;
            }catch(Exception)
            {
                return "";
            }
        }
    }
}
