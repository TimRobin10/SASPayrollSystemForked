using InfrastructureLayer.DataAccess.Repositories;
using ServicesLayer.AttendanceServices;
using ServicesLayer.EmployeeServices;

namespace ServicesLayer
{
    public class ServiceManager
    {
        private IUnitOfWork _unitOfWork;

        public IAttendanceService AttendanceService { get; private set; }
        public IEmployeeService EmployeeService { get; private set; }

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            AttendanceService = new AttendanceService(_unitOfWork);
            EmployeeService = new EmployeeService(_unitOfWork);
        }
    }
}
