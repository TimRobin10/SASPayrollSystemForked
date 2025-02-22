
namespace DomainLayer.Models.Employee
{
    public interface IEmployeeModel
    {
        DateTime DateOfBirth { get; set; }
        DateTime EmployementDate { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string? MiddleName { get; set; }
    }
}