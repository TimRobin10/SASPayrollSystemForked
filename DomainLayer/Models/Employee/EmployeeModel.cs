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
        private string _firstName = string.Empty;
        private string _middleInitial = string.Empty;
        private string _lastname = string.Empty;
        private string _jobTitle = string.Empty;

        private Formatter formatter = new Formatter();

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 - 50 characters")]
        public string FirstName
        {
            get => _firstName;
            set => _firstName = formatter.ToProperCase(value);
        }

        [Required(ErrorMessage = "Middle initial is required")]
        [StringLength(1, ErrorMessage = "Must be one character only")]
        public string MiddleInitial
        {
            get => _middleInitial;
            set => _middleInitial = formatter.ToProperCase(value);
        }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 - 50 characters")]
        public string LastName
        {
            get => _lastname;
            set => _lastname = formatter.ToProperCase(value);
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
