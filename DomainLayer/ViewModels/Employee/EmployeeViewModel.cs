using DomainLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(IEmployeeModel employeeModel)
        {
            EmployeeFullName = employeeModel.FullName;
            BirthDay = employeeModel.BirthDay.ToString("MMM dd, yyyy");
            EmploymentDate = employeeModel.EmploymentDate.ToString("MM/dd/yyyy");
            JobTitle = employeeModel.JobTitle;
            Department = employeeModel.Department.Name;
        }
        public string EmployeeFullName { get; private set; } = string.Empty;
        public string BirthDay { get; private set; } = string.Empty;
        public string EmploymentDate { get; private set; } = string.Empty;
        public string JobTitle { get; private set; } = string.Empty;
        public string Department { get; private set; } = string.Empty;
    }
}
