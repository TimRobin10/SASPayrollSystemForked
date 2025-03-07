using System.Security.Cryptography;


namespace DomainLayer
{
    public class Encryption
    {
        public static byte[] GenerateSalt(int size)
        {
            byte[] saltBytes = new byte[size];

            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(saltBytes);
            }

            return saltBytes;
        }

        public static byte[] EncryptSha256(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(input);
            }
        }
    }
}
