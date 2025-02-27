using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DomainLayer.Models.Leave
{
    public class LeaveModel : ILeaveModel
    {
        [Key]
        public int Id { get; set; }
        public DateOnly DateOfFiling { get; set; }
        public DateOnly DateOfAbsence { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; } = null!;
    }
}
