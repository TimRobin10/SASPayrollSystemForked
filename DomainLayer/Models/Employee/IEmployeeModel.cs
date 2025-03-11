using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Leave;

namespace DomainLayer.Models.Employee
{
    public interface IEmployeeModel
    {
        ICollection<AttendanceModel> Attendances { get; set; }
        decimal BasicDailyRate { get; set; }
        DateOnly BirthDay { get; set; }
        DepartmentModel Department { get; set; }
        DateOnly EmploymentDate { get; set; }
        string FirstName { get; set; }
        Guid Id { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        uint LeaveCredits { get; set; }
        ICollection<LeaveModel> Leaves { get; set; }
        string MiddleInitial { get; set; }
    }
}