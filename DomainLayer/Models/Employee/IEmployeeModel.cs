using DomainLayer.Models.Common;
using DomainLayer.Models.Department;

namespace DomainLayer.Models.Employee
{
    public interface IEmployeeModel : IEntityModel
    {
        string BankDetails { get; set; }
        decimal BasicRate { get; set; }
        string ContactNumber { get; set; }
        DateOnly DateOfBirth { get; set; }
        DepartmentModel Department { get; set; }
        int DepartmentId { get; set; }
        DateOnly EmployementDate { get; set; }
        string FirstName { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string PhilHealthNumber { get; set; }
        string SSSId { get; set; }
        string TINId { get; set; }
    }
}