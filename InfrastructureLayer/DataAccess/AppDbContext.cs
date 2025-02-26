using DomainLayer.Models.Attendance;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.DataAccess;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(".");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<AttendanceModel> Attendances { get; set; }
    public DbSet<AttendanceModel> Departments { get; set; }
    public DbSet<AttendanceModel> Employees { get; set; }
}
