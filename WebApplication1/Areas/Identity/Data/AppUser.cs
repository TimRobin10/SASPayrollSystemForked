using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Models.Attendance;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Areas.Identity.Data;

public class AppUser : IdentityUser
{
    public ICollection<AttendanceModel> Attendances { get; set; } = new List<AttendanceModel>();
}