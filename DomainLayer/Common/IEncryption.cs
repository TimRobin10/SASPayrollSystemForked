namespace DomainLayer.Common
{
    public interface IEncryption
    {
        byte[] GenerateHash(string password, byte[] saltBytes);
    }
}