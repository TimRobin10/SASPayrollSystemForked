using DomainLayer.Models.Role;
using DomainLayer.Models.UserRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.User
{
    public class UserModel : IUserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Username must be 2 - 20 characters only")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Salt is empty")]
        public string Salt { get; set; } = null!;

        [Required(ErrorMessage = "Password Hash is empty")]
        public string PasswordHash { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; } = null!;

        public virtual ICollection<UserRoleModel> UserRoles { get; } = [];
        public virtual ICollection<RoleModel> Roles { get; } = null!;
    }
}
