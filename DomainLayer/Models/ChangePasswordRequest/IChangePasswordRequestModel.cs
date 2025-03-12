using DomainLayer.Enums;

namespace DomainLayer.Models.ChangePasswordRequest
{
    public interface IChangePasswordRequestModel
    {
        DateOnly DateOfRequest { get; }
        Guid Id { get; set; }
        string Password { set; }
        byte[] PasswordHash { get; }
        byte[] Salt { get; }
        FormStatus Status { get; set; }
        TimeOnly TimeOfRequest { get; }
    }
}