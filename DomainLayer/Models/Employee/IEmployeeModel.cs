using DomainLayer.Models.Department;

namespace DomainLayer.Models.Employee
{
    public interface IEmployeeModel
    {
        string BankDetails { get; set; }
        decimal BasicRate { get; set; }
        string ContactNumber { get; set; }
        DateTime DateOfBirth { get; set; }
        IDepartmentModel Department { get; set; }
        int DepartmentId { get; set; }
        DateTime EmployementDate { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string PhilHealthNumber { get; set; }
        string SSSId { get; set; }
        string TINId { get; set; }
    }
}