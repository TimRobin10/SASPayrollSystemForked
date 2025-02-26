using DomainLayer.Models.Common;
using DomainLayer.Models.Department;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainLayer.Models.Employee
{
    public class EmployeeModel : IEntityModel, IEmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime EmployementDate { get; set; }
        public string JobTitle { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal BasicRate { get; set; }

        public string ContactNumber { get; set; } = null!;

        public string SSSId { get; set; } = null!;
        public string TINId { get; set; } = null!;
        public string PhilHealthNumber { get; set; } = null!;
        public string BankDetails { get; set; } = null!;


        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public IDepartmentModel Department { get; set; } = null!;

    }
}
