using DomainLayer.Models.Employee;

namespace DomainLayer.Models.Department
{
    public interface IDepartmentModel
    {
        ICollection<EmployeeModel> Employees { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }
}