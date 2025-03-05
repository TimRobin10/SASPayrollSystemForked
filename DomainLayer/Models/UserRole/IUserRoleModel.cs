using DomainLayer.Models.Role;
using DomainLayer.Models.User;

namespace DomainLayer.Models.UserRole
{
    public interface IUserRoleModel
    {
        RoleModel Role { get; set; }
        Guid RolesId { get; set; }
        UserModel User { get; set; }
        Guid UsersId { get; set; }
    }
}