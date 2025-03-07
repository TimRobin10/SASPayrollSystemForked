using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using ServicesLayer.Role;
using ServicesLayer.User;

namespace ServicesLayer
{
    public interface IServicesMesh
    {
        IRoleServices RoleServices { get; }
        IUserServices UserServices { get; }

        Task AddNewUserWithRole(IUserModel newUser, string roleName);
    }
}