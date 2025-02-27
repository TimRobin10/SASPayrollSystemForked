using DomainLayer.Models.Attendance;
using DomainLayer.Models.Employee;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace InfrastructureLayer.DataAccess;
public class AppUser : IdentityUser
{
    ICollection<AttendanceModel> Attendances { get; set; } = new List<AttendanceModel>();
}