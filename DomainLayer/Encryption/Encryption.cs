using System.Security.Cryptography;
using System.Text;


namespace DomainLayer
{
    public class Encryption
    {
        public static byte[] GenerateHash(string password, byte[] saltBytes)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var encryptedPasswordBytes = Encryption.EncryptSha256(passwordBytes);
            var saltedPasswordBytes = saltBytes.Concat(encryptedPasswordBytes).ToArray();
            var finalHash = Encryption.EncryptSha256(saltedPasswordBytes);

            return finalHash;
        }

        private static byte[] EncryptSha256(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(input);
            }
        }
    }
}
