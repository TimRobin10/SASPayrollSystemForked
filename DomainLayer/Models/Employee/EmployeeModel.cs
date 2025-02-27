using DomainLayer.Models.Attendance;
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

        public DateOnly DateOfBirth { get; set; }

        public DateOnly EmployementDate { get; set; }


        [Required]
        [StringLength(20)]
        public string JobTitle { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal BasicRate { get; set; }

        [RegularExpression(@"^\+63\d{10}$", ErrorMessage = "Please enter a valid cellphone number.")]
        public string ContactNumber { get; set; } = null!;

        [RegularExpression(@"^\d{2}-\d{7}-\d{1}$", ErrorMessage = "Please enter a valid SSS ID number")]
        public string SSSId { get; set; } = null!;

        [RegularExpression(@"^\d{3}-\d{3}-\d{3}-\d{3}$", ErrorMessage = "Please enter a valid TIN ID number")]
        public string TINId { get; set; } = null!;

        [RegularExpression(@"^\d{2}-\d{9}-\d{1}$", ErrorMessage = "Please enter a valid PhilHealth Id number")]
        public string PhilHealthNumber { get; set; } = null!;


        public string BankDetails { get; set; } = null!;

        public int LeaveCredits { get; set; }


        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; } = null!;
    }
}
