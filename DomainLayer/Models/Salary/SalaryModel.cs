using DomainLayer.Models.Attendance;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Leave;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Salary
{
    public class SalaryModel : ISalaryModel
    {
        private uint _days = 0;
        private uint _regularOT = 0;
        private uint _nights = 0;
        private uint _nightsOT = 0;

        private TimeOnly DayStart = new TimeOnly(6, 0, 0);
        private TimeOnly DayEnd = new TimeOnly(22, 0, 0);

        public SalaryModel()
        { }

        public SalaryModel(IEmployeeModel employee)
        {
            EmployeeId = employee.Id;
            Employee = (EmployeeModel)employee;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public required DateOnly PayDay { get; set; }

        [Column(TypeName = "tinyint")]
        public uint Days
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
                if (DaysAmount == 0)
                {
                    DaysAmount = Days * Employee.BasicDailyRate;
                    TotalBasic += DaysAmount;
                }
                else
                {
                    TotalBasic -= DaysAmount;
                    DaysAmount = Days * Employee.BasicDailyRate;
                    TotalBasic += DaysAmount;
                }
            }
        }

        [Column(TypeName = "money")]
        public decimal DaysAmount { get; set; } = 0;

        [Column(TypeName = "tinyint")]
        public uint RegularOT
        {
            get
            {
                return _regularOT;
            }
            set
            {
                _regularOT = value;
                RegularOTAmount = Employee.BasicDailyRate / 8 * 1.25m * RegularOT;
            }
        }

        [Column(TypeName = "money")]
        public decimal RegularOTAmount { get; set; }

        [Column(TypeName = "tinyint")]
        public uint Nights
        {
            get
            {
                return _nights;
            }
            set
            {
                _nights = value;
                if (NightsAmount == 0)
                {
                    NightsAmount = Employee.BasicDailyRate * Nights;
                    TotalBasic += NightsAmount;
                }
                else
                {
                    TotalBasic -= NightsAmount;
                    NightsAmount = Employee.BasicDailyRate * Nights;
                    TotalBasic += NightsAmount;
                }
            }
        }

        [Column(TypeName = "money")]
        public decimal NightsAmount { get; set; } = 0;

        [Column(TypeName = "tinyint")]
        public uint NightsOT
        {
            get
            {
                return _nightsOT;
            }
            set
            {
                _nightsOT = value;
                NightsOTAmount = Employee.BasicDailyRate / 8 * 1.25m * 1.10m * NightsOT;
            }
        }

        [Column(TypeName = "money")]
        public decimal NightsOTAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalBasic { get; private set; }

        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public EmployeeModel Employee;

        public void CalculateTotalSalary(IEnumerable<AttendanceModel> attendances, IEnumerable<LeaveModel> leaves)
        {
            uint totalDays = 0;
            uint totalNights = 0;

            uint totalRegularOT = 0;
            uint totalNightOT = 0;

            foreach (var attendance in attendances)
            {

                if (attendance.TimeIn.IsBetween(DayStart, DayEnd) && attendance.Status == Enums.FormStatus.Approved)
                {
                    totalDays++;
                    if (attendance.TotalHours > 8)
                    {
                        totalRegularOT += (attendance.TotalHours - 8);
                    }
                }
                else if (attendance.Status == Enums.FormStatus.Approved)
                {
                    totalNights++;
                    if (attendance.TotalHours > 8)
                    {
                        totalNightOT += (attendance.TotalHours - 8);
                    }
                }
            }

            var workYears = Employee.EmploymentDate.Year - DateOnly.FromDateTime(DateTime.Now).Year;
            foreach (var leave in leaves)
            {
                if (leave.Status == Enums.FormStatus.Approved && workYears >= 1)
                {
                    totalDays += leave.Duration;
                }
            }

            Days = totalDays;
            RegularOT = totalRegularOT;
            Nights = totalNights;
            NightsOT = totalNightOT;
        }
    }
}
