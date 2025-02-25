using DomainLayer.Models.Attendance;

namespace ServicesLayer.AttendanceServices
{
    interface IAttendanceRepository
    {
        void Add(AttendanceModel attendanceModel);
        void Update(AttendanceModel attendanceModel);
        void Delete(AttendanceModel attendanceModel);
        IEnumerable<AttendanceModel> GetAll();
        AttendanceModel Get(int id);
    }
}
