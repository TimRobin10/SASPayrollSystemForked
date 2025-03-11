using DomainLayer.Enums;

namespace DomainLayer.Models.Leave
{
    public interface ILeaveModel
    {
        DateOnly DateOfAbsence { get; set; }
        DateOnly DateOfFiling { get; set; }
        uint Duration { get; set; }
        Guid EmployeeId { get; set; }
        Guid Id { get; set; }
        FormStatus Status { get; set; }
    }
}