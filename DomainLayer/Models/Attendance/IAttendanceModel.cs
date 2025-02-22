
namespace DomainLayer.Models.Attendance
{
    public interface IAttendanceModel
    {
        DateTime Date { get; set; }
        int Id { get; set; }
        string? Status { get; set; }
        DateTime TimeIn { get; set; }
        DateTime TimeOut { get; set; }
        int TotalHours { get; set; }
    }
}