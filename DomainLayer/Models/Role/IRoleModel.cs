using DomainLayer.Models.User;
using DomainLayer.Models.UserRole;

namespace DomainLayer.Models.Role
{
    public interface IRoleModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string NormalizedName { get; }
        ICollection<UserRoleModel> UserRoles { get; }
        ICollection<UserModel> Users { get; }
    }
}