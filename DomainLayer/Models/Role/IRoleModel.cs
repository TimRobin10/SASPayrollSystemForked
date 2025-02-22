using DomainLayer.Models.Permission;
using DomainLayer.Models.User;

namespace DomainLayer.Models.Role
{
    public interface IRoleModel
    {
        string? Description { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        ICollection<IPermissionModel> Permissions { get; set; }
        IUserModel User { get; set; }
        int UserId { get; set; }
    }
}