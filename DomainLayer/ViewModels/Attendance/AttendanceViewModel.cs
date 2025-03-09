using DomainLayer.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.Attendance
{
    public class AttendanceViewModel : IAttendanceViewModel
    {
        public AttendanceViewModel(IAttendanceModel attendanceModel)
        {
            Date = attendanceModel.Date.ToString("MMM dd, yyyy");
            TimeIn = attendanceModel.TimeIn.ToString("hh:mm:ss tt");
            if (attendanceModel.TimeOut != null)
            {
                var timeOut = (TimeOnly)attendanceModel.TimeOut;
                TimeOut = timeOut.ToString("hh:mm:ss tt");
            }
            else
                TimeOut = "-";

            TotalHours = $"{attendanceModel.TotalHours} hours";
            Status = attendanceModel.Status.ToString();
        }

        public string Date { get; private set; }
        public string TimeIn { get; private set; }
        public string TimeOut { get; private set; }
        public string TotalHours { get; private set; }
        public string Status { get; private set; }
    }
}
