using DomainLayer.Common;
using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Leave;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Employee
{
    public class EmployeeModel : IEmployeeModel
    {
        private string _fullName = string.Empty;
        private string _jobTitle = string.Empty;

        private Formatter formatter = new Formatter();

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Must be between 2 - 70 characters")]
        public string FullName
        {
            get => _fullName;
            set => _fullName = formatter.ToProperCase(value);
        }

        [Required(ErrorMessage = "Birthday is required")]
        public DateOnly BirthDay { get; set; }

        [Required(ErrorMessage = "Employment date is required")]
        public DateOnly EmploymentDate { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between 2 - 50 characters")]
        public string JobTitle
        {
            get => _jobTitle;
            set => _jobTitle = formatter.ToProperCase(value);
        }

        public ICollection<AttendanceModel> Attendances { get; set; } = [];
        public virtual required DepartmentModel Department { get; set; }
        public ICollection<LeaveModel> Leaves { get; set; } = [];
    }
}
