using InfrastructureLayer.DataAccess.Repositories.Attendance;
using InfrastructureLayer.DataAccess.Repositories.Employee;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IAttendanceRepository attendanceRepository { get; }

        IEmployeeRepository employeeRepository { get; }

        void SaveChanges();
    }
}