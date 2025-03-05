using ServicesLayer.User;

namespace ServicesLayer
{
    public interface IServicesManager
    {
        IUserServices UserServices { get; }
    }
}