using System.ComponentModel.DataAnnotations;
using DomainLayer.Models.Attendance.Interfaces;
using DomainLayer.Models.Employee.Interfaces;


namespace DomainLayer.Models.Employee
{
    public class EmployeeModel : IEmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public ICollection<IAttendanceModel>? Attendances { get; set; }
    }
}
