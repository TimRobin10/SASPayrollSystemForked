using DomainLayer.Models.Role;

namespace DomainLayer.Models.User
{
    public interface IUserModel
    {
        string Email { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string PasswordSaltedHash { get; set; }
        string PhoneNumber { get; set; }
        ICollection<IRoleModel> Roles { get; set; }
    }
}