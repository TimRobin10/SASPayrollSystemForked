using DomainLayer.Models.Attendance.Interfaces;
using DomainLayer.Models.Employee.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Attendance
{
    public class AttendanceModel : IAttendanceModel
    {
        [Key]
        public int AttendanceId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime AttendanceTimeIn { get; set; }
        public DateTime AttendanceTimeOut { get; set; }
        public int AttendanceTotalHours { get; set; }
        public string? AttendanceStatus { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public virtual IEmployeeModel Employee { get; set; } = null!;

    }
}
