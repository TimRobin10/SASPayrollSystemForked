using DomainLayer.Models.Common;
using DomainLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Department
{
    public class DepartmentModel : IEntityModel, IDepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Decription { get; set; }
        public ICollection<IEmployeeModel>? Employees { get; set; }
    }
}