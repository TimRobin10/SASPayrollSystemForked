using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.User;
using DomainLayer.Models.Role;

namespace DomainLayer.Models.UserRole
{
    public class UserRoleModel : IUserRoleModel
    {
        [Key, Column(Order = 0)]
        public Guid UsersId { get; set; }

        [Key, Column(Order = 1)]
        public Guid RolesId { get; set; }

        public virtual UserModel User { get; set; } = null!;
        public virtual RoleModel Role { get; set; } = null!;
    }
}
