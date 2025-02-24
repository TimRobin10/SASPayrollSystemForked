using DomainLayer.Models.Common;
using DomainLayer.Models.Role;

namespace DomainLayer.Models.Permission
{
    public interface IPermissionModel
    {
        bool AllowDelete { get; set; }
        bool AllowRead { get; set; }
        bool AllowUpdate { get; set; }
        bool AllowWrite { get; set; }
        string? Description { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        IEntityModel Resource { get; set; }
        int ResourceId { get; set; }
        ICollection<IRoleModel> Roles { get; set; }
    }
}