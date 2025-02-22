using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DomainLayer.Models.Common;
using DomainLayer.Models.Role;

namespace DomainLayer.Models.User
{
    public class UserModel : IEntityModel, IUserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PasswordSaltedHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<IRoleModel> Roles { get; set; } = new List<IRoleModel>();
    }
}
