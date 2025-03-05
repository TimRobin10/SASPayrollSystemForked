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
    public class RoleModel : IRoleModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 - 20 characters only")]
        public string Name { get; set; } = null!;

        public string NormalizedName => NormalizeString(Name);

        private string NormalizeString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.ToUpperInvariant().Trim();
        }

        public virtual ICollection<UserRoleModel> UserRoles { get; } = [];
        public virtual ICollection<UserModel> Users { get; } = null!;
    }
}
