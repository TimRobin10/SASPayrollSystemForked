using DomainLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Department
{
    public class DepartmentModel : IDepartmentModel
    {
        private string _name = string.Empty;
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(20, ErrorMessage = "Must not exceed 20 characters")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = textInfo.ToTitleCase(value.Trim().ToLower());
            }
        }

        public virtual ICollection<EmployeeModel> Employees { get; set; } = [];
    }
}
