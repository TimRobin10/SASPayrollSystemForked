using DomainLayer.Models.Common;
using DomainLayer.Models.Role;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Permission
{
    public class PermissionModel : IEntityModel, IPermissionModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Action { get; set; } = null!;
        public string Resource { get; set; } = null!;

        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }
        public virtual IRoleModel Role { get; set; } = null!;


    }
}
