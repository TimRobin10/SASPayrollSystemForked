using DomainLayer.Models.Attendance;
using InfrastructureLayer.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.AttendanceRepository
{
    interface IAttendanceRepository : IRepository<AttendanceModel>
    {
        void Update(AttendanceModel attendance);
        void SaveChanges();
    }
}
