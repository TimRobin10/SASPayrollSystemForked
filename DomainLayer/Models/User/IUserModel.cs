using DomainLayer.Models.Role;

namespace DomainLayer.Models.User
{
    public interface IUserModel
    {
        string? Email { get; set; }
        Guid Id { get; set; }
        string Password { set; }
        byte[] PasswordHash { get; }
        string? PhoneNumber { get; set; }
        ICollection<RoleModel> Roles { get; }
        byte[] Salt { get; }
        string? Url { get; set; }
        string UserName { get; set; }
    }
}