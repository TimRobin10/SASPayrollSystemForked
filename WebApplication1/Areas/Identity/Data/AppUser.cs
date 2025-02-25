using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Employee;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Areas.Identity.Data;

public class AppUser : IdentityUser
{
    public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
}