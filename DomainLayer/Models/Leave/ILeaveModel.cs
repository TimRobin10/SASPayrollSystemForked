
using DomainLayer.Models.Common;

namespace DomainLayer.Models.Leave
{
    public interface ILeaveModel : IEntityModel
    {
        DateOnly DateOfAbsence { get; set; }
        DateOnly DateOfFiling { get; set; }
        int Duration { get; set; }
        string Status { get; set; }
    }
}