using InfrastructureLayer.DataAccess.Repositories.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
