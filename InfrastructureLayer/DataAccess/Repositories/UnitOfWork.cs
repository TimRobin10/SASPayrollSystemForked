using InfrastructureLayer.DataAccess.Repositories.Attendance;
using InfrastructureLayer.DataAccess.Repositories.Employee;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            attendanceRepository ??= new AttendanceRepository(_db);
        }

        public IAttendanceRepository attendanceRepository { get; private set; }

        public IEmployeeRepository employeeRepository { get; private set; }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
