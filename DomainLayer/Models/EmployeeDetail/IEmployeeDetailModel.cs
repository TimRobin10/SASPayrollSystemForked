
namespace DomainLayer.Models.EmployeeDetail
{
    public interface IEmployeeDetailModel
    {
        DateOnly EmployementDate { get; set; }
        string FirstName { get; set; }
        Guid Id { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string MiddleInitial { get; set; }
    }
}