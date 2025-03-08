﻿using System.Security.Cryptography;
using System.Text;


namespace DomainLayer
{
    public class Encryption : IEncryption
    {
        public byte[] GenerateHash(string password, byte[] saltBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var encryptedPasswordBytes = EncryptSha256(passwordBytes);
            var saltedPasswordBytes = saltBytes.Concat(encryptedPasswordBytes).ToArray();
            var finalHash = EncryptSha256(saltedPasswordBytes);

            return finalHash;
        }

        private byte[] EncryptSha256(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(input);
            }
        }
    }
}
