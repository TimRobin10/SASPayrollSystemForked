using DomainLayer.Models.Attendance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
