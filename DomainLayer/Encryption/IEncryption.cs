namespace DomainLayer
{
    public interface IEncryption
    {
        byte[] GenerateHash(string password, byte[] saltBytes);
    }
}