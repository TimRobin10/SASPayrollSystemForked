using DomainLayer.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainLayer.Models.Attendance
{
    public class AttendanceModel : IAttendanceModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateOnly Date { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly TimeIn { get; set; }
        [Column(TypeName = "time")]
        public TimeOnly TimeOut { get; set; }
        public int TotalHours { get; set; }
        public string Status { get; set; } = null!;

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public virtual EmployeeModel Employee { get; set; } = null!;
    }
}
