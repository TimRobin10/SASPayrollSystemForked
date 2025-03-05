using DomainLayer.Models.User;
using DomainLayer.Models.UserRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Role
{
    public class RoleModel
    {
        private string _normalizedString = string.Empty;

        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 - 20 characters only")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string NormalizedName
        {
            get => _normalizedString;
            set => _normalizedString = value.ToUpperInvariant().Trim();
        }

        public virtual ICollection<UserRoleModel> UserRoles { get; } = [];
        public virtual ICollection<UserModel> Users { get; } = null!;
    }
}
