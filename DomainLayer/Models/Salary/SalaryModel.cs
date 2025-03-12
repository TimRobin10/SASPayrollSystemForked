using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Salary
{
    public class SalaryModel
    {

        [Required]
        [Column(TypeName = "money")]
        public decimal BasicSalary { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public uint Days { get; set; }


    }
}
