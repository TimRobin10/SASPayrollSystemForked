using DomainLayer.Models.Employee.Interfaces;

namespace DomainLayer.Models.Attendance.Interfaces
{
    public interface IAttendanceModel
    {
        DateTime AttendanceDate { get; set; }
        int AttendanceId { get; set; }
        string? AttendanceStatus { get; set; }
        DateTime AttendanceTimeIn { get; set; }
        DateTime AttendanceTimeOut { get; set; }
        int AttendanceTotalHours { get; set; }
        IEmployeeModel Employee { get; set; }
        int EmployeeId { get; set; }
    }
}