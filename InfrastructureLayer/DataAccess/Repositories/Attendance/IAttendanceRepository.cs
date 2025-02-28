using DomainLayer.Models.Attendance;
using InfrastructureLayer.DataAccess.Repositories.Common;

namespace InfrastructureLayer.DataAccess.Repositories.Attendance
{
    public interface IAttendanceRepository : IRepository<IAttendanceModel>
    {
        void Update(IAttendanceModel attendance);
    }
}
