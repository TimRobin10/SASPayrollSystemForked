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

    public void Update(IAttendanceModel attendance)
    {
        _db.Attendances.Update((AttendanceModel)attendance);
    }
}
