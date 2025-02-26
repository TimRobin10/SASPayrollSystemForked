using DomainLayer.Models.Attendance;
using InfrastructureLayer.DataAccess.Repositories.Common;
using System.Linq.Expressions;
namespace InfrastructureLayer.DataAccess.Repositories.Attendance;

public class AttendanceRepository : Repository<IAttendanceModel>, IAttendanceRepository
{
    private readonly AppDbContext _db;
    public AttendanceRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Update(IAttendanceModel attendance)
    {
        _db.Attendances.Update((AttendanceModel)attendance);
    }
}
