using DomainLayer.Models.Employee;

namespace DomainLayer.Models.Payroll
{
    public interface IPayrollModel
    {
        decimal AddAdjustments { get; set; }
        decimal CashAdvance { get; set; }
        DateOnly CutOffEnd { get; set; }
        DateOnly CutOffStart { get; set; }
        uint Days { get; set; }
        decimal DaysAmount { get; set; }
        decimal DisposableIncome { get; set; }
        EmployeeModel Employee { get; set; }
        Guid EmployeeId { get; set; }
        int Id { get; set; }
        decimal IncomeNetOfTax { get; set; }
        decimal LatesDeductionAmount { get; set; }
        decimal LatesMinutes { get; set; }
        decimal NetPay { get; set; }
        uint Nights { get; set; }
        decimal NightsAmount { get; set; }
        uint NightsOT { get; set; }
        decimal NightsOTAmount { get; set; }
        decimal PagIbigAmount { get; set; }
        decimal PagIbigLoanAmount { get; set; }
        DateOnly PayrollDate { get; set; }
        decimal PhilHealthAmount { get; set; }
        uint RegularOT { get; set; }
        decimal RegularOTAmount { get; set; }
        bool SkipAttendancesAndLeaves { get; set; }
        decimal SSSAmount { get; set; }
        decimal SSSLoanAmount { get; set; }
        decimal SubtractAdjustments { get; set; }
        decimal TaxableIncome { get; set; }
        decimal TaxWithholdings { get; set; }
        decimal TotalBasic { get; }
        decimal TotalCompanyLoans { get; set; }
        decimal TotalContributions { get; set; }
        decimal TotalOT { get; set; }
        decimal Vale { get; set; }

        void UpdatePayroll(bool skipAttendancesAndLeaves = false);
    }
}