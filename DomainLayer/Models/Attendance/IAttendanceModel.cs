using DomainLayer.Models.Common;
using DomainLayer.Models.Employee;

namespace DomainLayer.Models.Attendance
{
    public interface IAttendanceModel : IEntityModel
    {
        DateTime Date { get; set; }
        IEmployeeModel Employee { get; set; }
        int EmployeeId { get; set; }
        string? Status { get; set; }
        DateTime TimeIn { get; set; }
        DateTime TimeOut { get; set; }
        int TotalHours { get; set; }
    }
}