using DomainLayer.Enums;
using DomainLayer.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Leave
{
    public class LeaveModel : ILeaveModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly DateOfFiling { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateOnly DateOfAbsence { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        public uint Duration { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public FormStatus Status { get; set; } = FormStatus.Pending;

        public virtual required EmployeeModel Employee { get; set; }
    }
}
