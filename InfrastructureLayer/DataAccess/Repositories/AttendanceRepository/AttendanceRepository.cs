using DomainLayer.Models.Attendance;
using InfrastructureLayer.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.AttendanceRepository
{
    public class AttendanceRepository : Repository<AttendanceModel>, IAttendanceRepository
    {
        private readonly AppDbContext _db;
        public AttendanceRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Update(AttendanceModel attendance)
        {
            _db.Attendances.Update(attendance);
        }
    }
}
