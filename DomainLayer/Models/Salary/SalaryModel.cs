using DomainLayer.Enums;
using DomainLayer.Models.Attendance;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Holiday;
using DomainLayer.Models.Leave;
using DomainLayer.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Salary
{
    public class SalaryModel
    {
        private const decimal _minimumSSSMonthlyCompRange = 5250;
        private const decimal _maximumSSSMonthlyCompRange = 34750;
        private const decimal _minimumSSSMonthlyContribution = 250;
        private const decimal _maximumSSSMonthlyContribution = 1750;

        private const decimal _minimumPhilHealthMonthlySalaryCap = 10000;
        private const decimal _maximumPhilHealthMonthlySalaryCap = 100000;
        private const decimal _minimumPhilHealthMonthlyContribution = 500;
        private const decimal _maximumPhilHealthMonthlyContribution = 5000;
        private const decimal _currentPhilHealthMonthlyRate = 0.05m;

        private const decimal _minimumPagIbigMonthlyComp = 1500;

        private uint _days = 0;
        private uint _regularOT = 0;
        private uint _nights = 0;
        private uint _nightsOT = 0;
        private decimal _latesMinutes = 0;

        private readonly TimeOnly DayStart = new TimeOnly(6, 0, 0);
        private readonly TimeOnly DayEnd = new TimeOnly(22, 0, 0);

        private readonly TimeOnly DayWorkShiftStart = new TimeOnly(8, 0, 0);
        private readonly TimeOnly DayWorkShiftEnd = new TimeOnly(17, 0, 0);

        public SalaryModel()
        { 
            
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(PayrollId))]
        public required Guid PayrollId { get; set; }
        public required PayrollModel Payroll { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public required Guid EmployeeId { get; set; }
        public required EmployeeModel Employee { get; set; }

        //Basic
            //Normal Days and Nights Worked
        [Column(TypeName = "tinyint")]
        public uint DaysWorked
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
                DaysAmount = GetAmount(DaysWorked, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays);
            }
        }
        [Column(TypeName = "money")]
        public decimal DaysAmount { get; set; } = 0;
        [Column(TypeName = "tinyint")]
        public uint NightsWorked
        {
            get
            {
                return _nights;
            }
            set
            {
                _nights = value;
                NightsAmount = GetAmount(NightsWorked, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays, false);
            }
        }
        [Column(TypeName = "money")]
        public decimal NightsAmount { get; set; } = 0;
        
            //Regular Holidays Days and Nights Worked
        private uint _regularHolidaysWorked = 0;
        [Column(TypeName = "tinyint")]
        public uint RegularHolidaysWorked 
        {
            get
            {
                return _regularHolidaysWorked;
            }
            set
            {
                _regularHolidaysWorked = value;
                RegularHolidaysWorkedAmount
                    = GetAmount(RegularHolidaysWorked, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays, true, HolidayType.Regular);
            }
        }
        [Column(TypeName = "money")]
        public decimal RegularHolidaysWorkedAmount { get; set; } = 0;

        private uint _regularHolidayNightsWorked = 0;
        [Column(TypeName = "tinyint")]
        public uint RegularHolidayNightsWorked
        {
            get
            {
                return _regularHolidayNightsWorked;
            }
            set
            {
                _regularHolidayNightsWorked = value;
                RegularHolidayNightsAmount
                    = GetAmount(RegularHolidayNightsWorked, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays, false, HolidayType.Regular);
            }
        }
        [Column(TypeName = "money")]
        public decimal RegularHolidayNightsAmount { get; set; } = 0;


        private uint _specialDays = 0;
        [Column(TypeName = "tinyint")]
        public uint SpecialWorkingHolidaysWorked 
        {
            get
            {
                return _specialDays;
            }
            set
            {
                _specialDays = value;
                SpecialWorkingHolidaysAmount
                    = GetAmount(SpecialWorkingHolidaysWorked, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays, true, HolidayType.SpecialNonWorking);
            }
        }
        [Column(TypeName = "money")]
        public decimal SpecialWorkingHolidaysAmount { get; set; } = 0;

        private uint _specialNights = 0;
        [Column(TypeName = "tinyint")]
        public uint SpecialWorkingHolidayNightsWorked
        {
            get
            {
                return _specialNights;
            }
            set
            {
                _specialNights = value;
                SpecialWorkingHolidaysNightsAmount
                    = GetAmount(SpecialWorkingHolidayNightsWorked, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays, false, HolidayType.SpecialNonWorking);
            }
        }
        [Column(TypeName = "money")]
        public decimal SpecialWorkingHolidaysNightsAmount { get; set; }

        //OTs
            //Working Days
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
                RegularOTAmount = GetRegularOTAmount(RegularOT, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays);
            }
        }

        [Column(TypeName = "money")]
        public decimal RegularOTAmount { get; set; } = 0;

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
                NightsOTAmount = GetNightsOTAmount(NightsOT, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays);
            }
        }

        [Column(TypeName = "money")]
        public decimal NightsOTAmount { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal TotalOT { get; set; } = 0;

        //Deductions
        [Column(TypeName = "decimal")]
        public decimal LatesMinutes
        {
            get
            {
                return _latesMinutes;
            }
            set
            {
                _latesMinutes = value;
                LatesDeductionAmount = GetLatesDeductionAmount(LatesMinutes, Employee.BasicSemiMonthlyRate, Payroll.TotalWorkingDays);
            }
        }
        
        [Column(TypeName = "money")]
        public decimal LatesDeductionAmount { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal TotalBasic { get; private set; } = 0;

        //Contributions
        [Column(TypeName = "money")]
        public decimal SSSAmount { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal PagIbigAmount { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal PhilHealthAmount { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal TotalContributions { get; set; } = 0;

        //Income Tax
        [Column(TypeName = "money")]
        public decimal TaxableIncome { get; set; } = 0;
        [Column(TypeName = "money")]
        public decimal TaxWithholdings { get; set; } = 0;
        [Column(TypeName = "money")]
        public decimal IncomeNetOfTax { get; set; } = 0;

        //Loans
        [Column(TypeName = "money")]
        public decimal SSSLoanAmount { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal PagIbigLoanAmount { get; set; } = 0;


        [Column(TypeName = "money")]
        public decimal DisposableIncome { get; set; } = 0;


        //Company Loans
        [Column(TypeName = "money")]
        public decimal CashAdvance { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal Vale { get; set; } = 0;

        [Column(TypeName = "money")]
        public decimal TotalCompanyLoans { get; set; } = 0;

        //Adjustments
        [Column(TypeName = "money")]
        public decimal AddAdjustments { get; set; } = 0;
        [Column(TypeName = "money")]
        public decimal SubtractAdjustments { get; set; } = 0;


        [Column(TypeName = "money")]
        public decimal NetPay { get; set; } = 0;


        //Atomic Operation
        public void UpdateSalary(bool skipAttendances = false, bool skipLeaves = false)
        {
            if (!skipAttendances)
                ApplyAttendances(Employee.Attendances);
            if (!skipLeaves)
                ApplyLeaves(Employee.Leaves);
            TotalBasic = GetTotalBasic(DaysAmount, NightsAmount, LatesDeductionAmount);
            TotalOT = RegularOTAmount + NightsOTAmount;
            CalculateContributions(Employee.BasicSemiMonthlyRate * 2);
            TotalContributions = SSSAmount + PagIbigAmount + PhilHealthAmount;
            TaxableIncome = TotalBasic + TotalOT - TotalContributions;
            TaxWithholdings = CalculateTaxWithholdings(TaxableIncome);
            IncomeNetOfTax = TaxableIncome - TaxWithholdings;
            DisposableIncome = IncomeNetOfTax - SSSLoanAmount - PagIbigLoanAmount;
            TotalCompanyLoans = CashAdvance + Vale;
            NetPay = DisposableIncome - TotalCompanyLoans + AddAdjustments - SubtractAdjustments;
        }

        //Money Operations
            //Basics
        private decimal GetAmount(uint presents, decimal basicSemiMonthlyRate, uint totalDays, bool day = true, HolidayType holidayType = HolidayType.Not)
        {
            var normal = presents * basicSemiMonthlyRate / totalDays;
            if (!day)   //Night
                normal = normal * 1.1m;
            if (holidayType == HolidayType.Regular) //Regular Holiday
                normal = normal * 2;
            if (holidayType == HolidayType.SpecialNonWorking)  //Special NonWorking
                normal = normal * 1.3m;
            return normal;
        }
        
            //OTs
        private decimal GetRegularOTAmount(uint regularOT, decimal basicSemiMonthlyRate, uint totalDays)
        {
            return regularOT * basicSemiMonthlyRate / totalDays / 8 * 1.3m;
        }
        private decimal GetNightsOTAmount(uint nightsOT, decimal basicSemiMonthlyRate, uint totalDays)
        {
            return nightsOT * basicSemiMonthlyRate / totalDays / 8 * 1.3m * 1.10m;
        }
        
        //Deductions
        private decimal GetLatesDeductionAmount(decimal latesMinutes, decimal basicSemiMonthly, uint totalDays)
        {
            return latesMinutes * basicSemiMonthly / totalDays / 480;
        }
        
        private decimal GetTotalBasic(decimal daysAmount, decimal nightsAmount, decimal latesDeductions)
        {
            return daysAmount + nightsAmount - latesDeductions;
        }
        
            //Contributions
        private void CalculateContributions(decimal basicMonthlySalary)
        {
            SSSAmount = CalculateSSSAmount(basicMonthlySalary);
            PagIbigAmount = CalculatePagIbigAmount(basicMonthlySalary);
            PhilHealthAmount = CalculatePhilHealthAmount(basicMonthlySalary);
        }
        private decimal CalculateSSSAmount(decimal basicMonthlySalary)
        {
            decimal finalMonthlyAmount = 0;
            if (basicMonthlySalary < _minimumSSSMonthlyCompRange)
                finalMonthlyAmount = _minimumSSSMonthlyContribution;
            else if (basicMonthlySalary >= _maximumSSSMonthlyCompRange)
                finalMonthlyAmount = _maximumSSSMonthlyContribution;
            else
            {
                decimal baseCompensation = basicMonthlySalary - _minimumSSSMonthlyCompRange;
                finalMonthlyAmount = 25 * (Math.Floor(baseCompensation / 500) + 1) + _minimumSSSMonthlyContribution;
            }
            return finalMonthlyAmount / 2;
        }
        private decimal CalculatePagIbigAmount(decimal basicMonthlySalary)
        {
            if (basicMonthlySalary <= _minimumPagIbigMonthlyComp)
                return basicMonthlySalary * 0.03m / 2;
            return basicMonthlySalary * 0.04m / 2;
        }
        private decimal CalculatePhilHealthAmount(decimal basicMonthlySalary)
        {
            if (basicMonthlySalary <= _minimumPhilHealthMonthlySalaryCap)
                return _minimumPhilHealthMonthlyContribution / 4;
            else if (basicMonthlySalary >= _maximumPhilHealthMonthlySalaryCap)
                return _maximumPhilHealthMonthlyContribution / 4;
            return basicMonthlySalary * _currentPhilHealthMonthlyRate / 4;
        }
        private decimal CalculateTaxWithholdings(decimal taxableIncome)
        {
            decimal finalAmount = 0;
            if (taxableIncome <= 10417)
                finalAmount = 0;
            else if (taxableIncome > 10417 && taxableIncome <= 16667)
                finalAmount = 0.15m * (taxableIncome - 10416.67m);
            else if (taxableIncome > 16667 && taxableIncome <= 33333)
                finalAmount = 0.20m * (taxableIncome - 16666.67m) + 937.5m;
            else if (taxableIncome > 33333 && taxableIncome <= 83333)
                finalAmount = 0.25m * (taxableIncome - 33333.33m) + 4270.83m;
            else if (taxableIncome > 83333 && taxableIncome <= 333333)
                finalAmount = 0.3m * (taxableIncome - 83333.33m) + 16770.83m;
            else
                finalAmount = 0.35m * (taxableIncome - 333333.33m) + 91770.83m;

            return finalAmount;
        }


        //private void ApplyAttendancesAndLeaves(IEnumerable<AttendanceModel> attendances, IEnumerable<LeaveModel> leaves)
        //{
        //    uint totalDays = 0;
        //    uint totalNights = 0;
        //    decimal totalMinutesLate = 0;

        //    uint totalRegularOT = 0;
        //    uint totalNightOT = 0;

        //    foreach (var attendance in attendances)
        //    {
        //        if (IsDateBetween(attendance.Date, Payroll.CutOffStart, Payroll.CutOffEnd) && attendance.Status == FormStatus.Approved)
        //        {
        //            if (attendance.TimeIn.IsBetween(DayStart, DayEnd))
        //            {
        //                totalDays++;
        //                if (attendance.TotalHours > 8)
        //                {
        //                    totalRegularOT += (attendance.TotalHours - 8);
        //                }
        //                if (attendance.TimeIn > DayWorkShiftStart)
        //                {
        //                    var span = attendance.TimeIn - DayWorkShiftStart;
        //                    totalMinutesLate += (decimal)span.TotalMinutes;
        //                }
        //            }
        //            else
        //            {
        //                totalNights++;
        //                if (attendance.TotalHours > 8)
        //                {
        //                    totalNightOT += (attendance.TotalHours - 8);
        //                }
        //            }
        //        }
        //    }

        //    foreach (var leave in leaves)
        //    {
        //        if (IsDateBetween(leave.DateOfAbsence, Payroll.CutOffStart, Payroll.CutOffEnd) && leave.Status == FormStatus.Approved)
        //            totalDays += leave.Duration;
        //    }

        //    Days = totalDays;
        //    RegularOT = totalRegularOT;
        //    Nights = totalNights;
        //    NightsOT = totalNightOT;
        //    LatesMinutes = totalMinutesLate;
        //}

        //Time Operations
        private void ApplyAttendances(IEnumerable<AttendanceModel> attendances) 
        {
            uint totalWorkingDays = 0;
            uint totalWorkingNights = 0;

            uint totalRegularHolidayDays = 0;
            uint totalRegularHolidayNights = 0;

            uint totalSpecialDays = 0;
            uint totalSpecialNights = 0;

            uint totalRegularOT = 0;
            uint totalNightOT = 0;
            decimal totalMinutesLate = 0;
            foreach (var attendance in attendances)
            {
                var holiday = Payroll.Holidays.Where(h => h.Date == attendance.Date).FirstOrDefault();
                if (IsDateBetween(attendance.Date, Payroll.CutOffStart, Payroll.CutOffEnd) && attendance.Status == FormStatus.Approved)
                {
                    if (attendance.TimeIn.IsBetween(DayStart, DayEnd))
                    {
                        if (holiday != null)
                        {
                            if (holiday.Type == HolidayType.Regular)
                                totalRegularHolidayDays++;
                            else if (holiday.Type == HolidayType.Regular)
                                totalSpecialDays++;
                        }
                        else
                            totalWorkingDays++;
                        if (attendance.TotalHours > 8)
                        {
                            totalRegularOT += (attendance.TotalHours - 8);
                        }
                        if (attendance.TimeIn > DayWorkShiftStart)
                        {
                            var span = attendance.TimeIn - DayWorkShiftStart;
                            totalMinutesLate += (decimal)span.TotalMinutes;
                        }
                    }
                    else
                    {
                        totalWorkingNights++;
                        if (attendance.TotalHours > 8)
                        {
                            totalNightOT += (attendance.TotalHours - 8);
                        }
                        if (attendance.TimeIn > DayWorkShiftEnd)
                        {
                            var span = attendance.TimeIn - DayWorkShiftStart;
                            totalMinutesLate += (decimal)span.TotalMinutes;
                        }
                    }
                }
            }

            DaysWorked = totalWorkingDays;
            RegularOT = totalRegularOT;
            NightsWorked = totalWorkingNights;
            NightsOT = totalNightOT;
            LatesMinutes = totalMinutesLate;
        }

        private void A(IEnumerable<AttendanceModel> attendances)
        {
            var normalDays = attendances
                .Where(a => IsDateBetween(a.Date, Payroll.CutOffStart, Payroll.CutOffEnd) && a.Status == FormStatus.Approved)
                .Where(a => a.TimeIn.IsBetween(DayStart, DayEnd))
                .Where(a => Payroll.Holidays.Where(h => h.Date == a.Date).FirstOrDefault() == null)
                .ToList();

            DaysWorked = (uint)normalDays.Count();


            var regHDays = attendances
                .Where(a => IsDateBetween(a.Date, Payroll.CutOffStart, Payroll.CutOffEnd) && a.Status == FormStatus.Approved)
                .Where(a => a.TimeIn.IsBetween(DayStart, DayEnd))
                .Where(a => Payroll.Holidays.Where(h => h.Date == a.Date && h.Type == HolidayType.Regular).FirstOrDefault() != null)
                .ToList();

            RegularHolidaysWorked = (uint)regHDays.Count();

            var specHDays = attendances
                .Where(a => IsDateBetween(a.Date, Payroll.CutOffStart, Payroll.CutOffEnd) && a.Status == FormStatus.Approved)
                .Where(a => a.TimeIn.IsBetween(DayStart, DayEnd))
                .Where(a => Payroll.Holidays.Where(h => h.Date == a.Date && h.Type == HolidayType.SpecialNonWorking).FirstOrDefault() != null)
                .ToList();

            SpecialWorkingHolidaysWorked = (uint)specHDays.Count();

            var normalNights = attendances
                .Where(a => IsDateBetween(a.Date, Payroll.CutOffStart, Payroll.CutOffEnd) && a.Status == FormStatus.Approved)
                .Where(a => !a.TimeIn.IsBetween(DayStart, DayEnd))
                .Where(a => Payroll.Holidays.Where(h => h.Date == a.Date).FirstOrDefault() == null)
                .ToList();

            

        }

        private void ApplyLeaves(IEnumerable<LeaveModel> leaves) 
        {
            uint totalDays = 0;
            foreach (var leave in leaves)
            {
                if (IsDateBetween(leave.DateOfAbsence, Payroll.CutOffStart, Payroll.CutOffEnd) && leave.Status == FormStatus.Approved)
                    totalDays += leave.Duration;
            }
            DaysWorked += totalDays;
        }
        private bool IsDateBetween(DateOnly date, DateOnly start, DateOnly end)
        {
            return date >= start && date <= end;
        }
    }
}
