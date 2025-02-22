using DomainLayer.Models.Role;

namespace DomainLayer.Models.Permission
{
    public interface IPermissionModel
    {
        string Action { get; set; }
        string? Description { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Resource { get; set; }
        IRoleModel Role { get; set; }
        int RoleId { get; set; }
    }
}