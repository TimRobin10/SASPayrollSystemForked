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
            EmployeeFullName = $"{employeeModel.FirstName} {employeeModel.MiddleInitial} {employeeModel.LastName}";
        }
        public string EmployeeFullName { get; private set; } = string.Empty;
    }
}
