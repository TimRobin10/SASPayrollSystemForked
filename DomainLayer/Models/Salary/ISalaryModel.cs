using DomainLayer.Models.Attendance;
using DomainLayer.Models.Leave;

namespace DomainLayer.Models.Salary
{
    public interface ISalaryModel
    {
        uint Days { get; set; }
        decimal DaysAmount { get; set; }
        Guid EmployeeId { get; set; }
        int Id { get; set; }
        uint Nights { get; set; }
        decimal NightsAmount { get; set; }
        uint NightsOT { get; set; }
        decimal NightsOTAmount { get; set; }
        DateOnly PayDay { get; set; }
        uint RegularOT { get; set; }
        decimal RegularOTAmount { get; set; }
        decimal TotalBasic { get; }

        void CalculateTotalSalary(IEnumerable<AttendanceModel> attendances, IEnumerable<LeaveModel> leaves);
    }
}