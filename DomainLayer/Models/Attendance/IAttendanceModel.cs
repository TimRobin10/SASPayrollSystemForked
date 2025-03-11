using DomainLayer.Enums;

namespace DomainLayer.Models.Attendance
{
    public interface IAttendanceModel
    {
        DateOnly Date { get; set; }
        Guid EmployeeId { get; set; }
        Guid Id { get; set; }
        FormStatus Status { get; set; }
        TimeOnly TimeIn { get; set; }
        TimeOnly? TimeOut { get; set; }
        uint TotalHours { get; }
    }
}