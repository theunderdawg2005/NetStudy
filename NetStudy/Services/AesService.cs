using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Services
{
    public class AesService
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;
       

        public AesService()
        {

        }

        public AesService(byte[] key, byte[] iv)
        {
            _key = key;
            _iv = iv;
        }

        public void GenerateAesKey(string groupId)
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                string keyFilePath = $"{groupId}_key.dat";
                SaveKeyWithDPAPI(keyFilePath, Convert.ToBase64String(aes.Key));
            }
        }

        public void SaveKeyWithDPAPI(string filePath, string aesKey)
        {
            byte[] encryptedKey = ProtectedData.Protect(
                System.Text.Encoding.UTF8.GetBytes(aesKey),
                null,
                DataProtectionScope.CurrentUser);

            File.WriteAllBytes(filePath, encryptedKey);
        }

        public string LoadKeyWithDPAPI(string groupId)
        {
            string filePath = $"{groupId}_key.dat";
            byte[] encryptedKey = File.ReadAllBytes(filePath);
            byte[] decryptedKey = ProtectedData.Unprotect(
                encryptedKey,
                null,
                DataProtectionScope.CurrentUser);

            return System.Text.Encoding.UTF8.GetString(decryptedKey);
        }

        public string EncryptMessage(string plainText, string key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetKeyBytes(key);
                aes.GenerateIV();

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                    string encryptedText = Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(encryptedBytes);
                    return encryptedText;
                }
            }
        }
        public string DecryptMessage(string encryptedText, string key)
        {
            string[] parts = encryptedText.Split(':');
            if (parts.Length != 2)
            {
                throw new FormatException("Dữ liệu mã hóa không hợp lệ.");
            }

            byte[] iv = Convert.FromBase64String(parts[0]);
            byte[] encryptedBytes = Convert.FromBase64String(parts[1]);

            using (Aes aes = Aes.Create())
            {
                aes.Key = GetKeyBytes(key);
                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
        private byte[] GetKeyBytes(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
        }

        public byte[] GetKey() => _key;
        public byte[] GetIV() => _iv;
    }
}
