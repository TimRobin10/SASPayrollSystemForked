using DomainLayer.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.AttendanceServices
{
    interface IAttendanceService
    {
        void ValidateModel(AttendanceModel attendanceModel);
    }
}
