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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Salt is empty")]
        public string Salt { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Hash is empty")]
        public string PasswordHash { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\+639\d{9}")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Must be exactly 12 characters")]
        public string PhoneNumber { get; set; } = null!;

        [Url(ErrorMessage = "Must be a valid Url")]
        public string? Url { get; set; }

        public virtual ICollection<UserRoleModel> UserRoles { get; } = [];
        public virtual ICollection<RoleModel> Roles { get; } = null!;
    }
}
