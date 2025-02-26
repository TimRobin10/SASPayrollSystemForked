using DomainLayer.Models.Employee;
using Microsoft.AspNetCore.Identity;


namespace InfrastructureLayer.DataAccess;
public class AppUser : IdentityUser
{
    public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
}