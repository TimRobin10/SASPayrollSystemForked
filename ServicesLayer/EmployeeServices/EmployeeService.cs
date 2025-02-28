using DomainLayer.Models.Employee;
using InfrastructureLayer.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.EmployeeServices
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(IEmployeeModel employeeModel)
        {
            _unitOfWork.employeeRepository.Add((EmployeeModel)employeeModel);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int employeeId)
        { 
            var employee = _unitOfWork.employeeRepository.Get(e => e.Id == employeeId);
            if (employee != null) 
            {
                _unitOfWork.employeeRepository.Remove(employee);
            }
            _unitOfWork.SaveChanges();
        }
    }
}
