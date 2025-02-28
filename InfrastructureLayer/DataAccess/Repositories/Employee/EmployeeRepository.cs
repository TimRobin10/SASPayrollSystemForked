using DomainLayer.Models.Employee;
using InfrastructureLayer.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Employee
{
    public class EmployeeRepository : Repository<EmployeeModel>, IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(IEmployeeModel employee)
        {
            _db.Employees.Update((EmployeeModel)employee);
        }
    }
}
