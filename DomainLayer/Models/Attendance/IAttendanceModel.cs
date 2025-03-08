using DomainLayer.Enums;
using DomainLayer.Models.Employee;

namespace DomainLayer.Models.Attendance
{
    public interface IAttendanceModel
    {
        DateOnly Date { get; set; }
        EmployeeModel Employee { get; set; }
        Guid Id { get; set; }
        FormStatus Status { get; set; }
        TimeOnly TimeIn { get; set; }
        TimeOnly? TimeOut { get; set; }
        uint TotalHours { get; }
    }
}