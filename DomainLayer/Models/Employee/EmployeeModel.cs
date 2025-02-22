using DomainLayer.Models.Common;
using System.ComponentModel.DataAnnotations;


namespace DomainLayer.Models.Employee
{
    public class EmployeeModel : IEntityModel, IEmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime EmployementDate { get; set; }
    }
}
