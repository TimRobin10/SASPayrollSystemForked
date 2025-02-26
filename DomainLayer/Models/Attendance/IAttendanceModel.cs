using DomainLayer.Models.Common;
using DomainLayer.Models.Employee;

namespace DomainLayer.Models.Attendance
{
    public interface IAttendanceModel : IEntityModel
    {
        DateTime Date { get; set; }
        EmployeeModel Employee { get; set; }
        int EmployeeId { get; set; }
        string? Status { get; set; }
        TimeOnly TimeIn { get; set; }
        TimeOnly TimeOut { get; set; }
        int TotalHours { get; set; }
    }
}