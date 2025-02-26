using DomainLayer.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainLayer.Models.Attendance
{
    public class AttendanceModel : IAttendanceModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public int TotalHours { get; set; }
        public string? Status { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public virtual IEmployeeModel Employee { get; set; } = null!;
    }
}
