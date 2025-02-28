using DomainLayer.Models.Employee;
using InfrastructureLayer.DataAccess.Repositories.Common;

namespace InfrastructureLayer.DataAccess.Repositories.Employee
{
    public interface IEmployeeRepository : IRepository<EmployeeModel>
    {
        void Update(IEmployeeModel employee);
    }
}