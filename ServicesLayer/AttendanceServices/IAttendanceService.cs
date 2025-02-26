using DomainLayer.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.AttendanceServices
{
    public interface IAttendanceService
    {
        void ValidateModel(IAttendanceModel attendanceModel);
        void Add(IAttendanceModel attendanceModel);
        void Update(IAttendanceModel attendanceModel);
        void Delete(int attendanceId);
        ICollection<IAttendanceModel> GetAttendanceModel();
    }
}
