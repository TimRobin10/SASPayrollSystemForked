namespace DomainLayer.ViewModels.Attendance
{
    public interface IAttendanceViewModel
    {
        string Date { get; }
        string Status { get; }
        string TimeIn { get; }
        string TimeOut { get; }
        string TotalHours { get; }
    }
}