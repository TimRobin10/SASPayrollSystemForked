using DomainLayer.Models.Common;
using DomainLayer.Models.Role;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Permission
{
    public class PermissionModel(IEntityModel resource) : IEntityModel, IPermissionModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowWrite { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowUpdate { get; set; }

        public ICollection<IRoleModel> Roles { get; set; } = new List<IRoleModel>();

        [ForeignKey(nameof(ResourceId))]
        public int ResourceId { get; set; }
        public IEntityModel Resource { get; set; } = resource;
    }
}
