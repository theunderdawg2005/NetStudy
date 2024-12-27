using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NetStudy.Services
{
    public class RsaService
    {
        private readonly RSA _rsa;

        public RsaService()
        {
            _rsa = RSA.Create();
        }

        // Tạo cặp khóa RSA (Public & Private)
        public (string publicKey, string privateKey) GenerateKeys()
        {
            string publicKey = Convert.ToBase64String(_rsa.ExportSubjectPublicKeyInfo());
            string privateKey = Convert.ToBase64String(_rsa.ExportPkcs8PrivateKey());
            return (publicKey, privateKey);
        }

        // Import Public Key (từ server)
        public void ImportPublicKey(string publicKey)
        {
            byte[] keyBytes = Convert.FromBase64String(publicKey);
            _rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);
        }

        // Import Private Key (để giải mã)
        public void ImportPrivateKey(string privateKey)
        {
            byte[] keyBytes = Convert.FromBase64String(privateKey);
            _rsa.ImportPkcs8PrivateKey(keyBytes, out _);
        }

        // Mã hóa AES Key bằng Public Key
        public string Encrypt(byte[] aesKeyBytes, string publicKey)
        {
            byte[] encryptedBytes = _rsa.Encrypt(aesKeyBytes, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedBytes);
        }

        // Giải mã AES Key bằng Private Key
        public string Decrypt(string encryptedAesKey)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedAesKey);
            byte[] decryptedBytes = _rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        private void GenerateRsaKeys()
        {
            var rsaService = new RsaService();

            // Tạo cặp khóa Public và Private
            var (publicKey, privateKey) = rsaService.GenerateKeys();

            // Lưu Private Key trên client
            File.WriteAllText("private_key.pem", privateKey);

            // Gửi Public Key lên server
            SendPublicKeyToServer(publicKey);
        }

        private void SendPublicKeyToServer(string publicKey)
        {
            // Gửi publicKey đến server qua API hoặc WebSocket
            // Ví dụ:
            Console.WriteLine("Gửi Public Key lên server: " + publicKey);
        }
        private string DecryptAesKey(string encryptedAesKey)
        {
            var rsaService = new RsaService();

            // Load Private Key từ file
            string privateKey = File.ReadAllText("private_key.pem");

            // Import Private Key
            rsaService.ImportPrivateKey(privateKey);

            // Giải mã AES Key
            return rsaService.Decrypt(encryptedAesKey);
        }
    }
}
