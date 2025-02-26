using InfrastructureLayer.DataAccess.Repositories.Attendance;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IAttendanceRepository attendanceRepository { get; }

        void SaveChanges();
    }
}