using DomainLayer.Models.Attendance.Interfaces;

namespace DomainLayer.Models.Employee.Interfaces
{
    public interface IEmployeeModel
    {
        ICollection<IAttendanceModel>? Attendances { get; set; }
        int EmployeeId { get; set; }
        string EmployeeName { get; set; }
    }
}