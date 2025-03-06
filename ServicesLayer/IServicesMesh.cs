using ServicesLayer.Role;
using ServicesLayer.User;

namespace ServicesLayer
{
    public interface IServicesMesh
    {
        IRoleServices RoleServices { get; }
        IUserServices UserServices { get; }
    }
}