using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using ServicesLayer.Common;

namespace ServicesLayer
{
    public interface IServicesMesh
    {
        IBaseServices<RoleModel> RoleServices { get; }
        IBaseServices<UserModel> UserServices { get; }

        Task<bool> LoginUser(string username, string password);

        Task AddNewUserWithRoleAsync(IUserModel newUser, string roleName);

        Task InitialSeeding();
    }
}