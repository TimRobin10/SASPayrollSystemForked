
namespace DomainLayer.Models.NewUserRequest
{
    public interface INewUserRequestModel
    {
        DateOnly DateOfRequest { get; }
        string Email { get; set; }
        Guid Id { get; set; }
        string Password { set; }
        byte[] PasswordHash { get; }
        byte[] Salt { get; }
        TimeOnly TimeOfRequest { get; }
        string UserName { get; set; }
    }
}