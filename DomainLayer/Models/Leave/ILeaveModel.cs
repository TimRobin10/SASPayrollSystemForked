using DomainLayer.Enums;
using DomainLayer.Models.Employee;

namespace DomainLayer.Models.Leave
{
    public interface ILeaveModel
    {
        DateOnly DateOfAbsence { get; set; }
        DateOnly DateOfFiling { get; set; }
        uint Duration { get; set; }
        EmployeeModel Employee { get; set; }
        Guid Id { get; set; }
        FormStatus Status { get; set; }
    }
}