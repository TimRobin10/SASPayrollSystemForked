using DomainLayer.Models.Common;
using DomainLayer.Models.Permission;
using DomainLayer.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Role
{
    public class RoleModel : IEntityModel, IRoleModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public IUserModel User { get; set; } = null!;

        public ICollection<IPermissionModel> Permissions { get; set; } = new List<IPermissionModel>();
    }
}
