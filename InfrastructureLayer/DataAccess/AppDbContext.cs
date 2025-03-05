using DomainLayer.Models.EmployeeDetail;
using DomainLayer.Models.Role;
using DomainLayer.Models.User;
using DomainLayer.Models.UserRole;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess
{
    public class AppDbContext : DbContext
    {
        private const string connectionStringHome = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SASPayrollDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private const string connectionStringLab = "Data Source=(localdb)\\ProjectModels;Initial Catalog=SASPayrollDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringHome);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleModel>()
                .HasKey(m => new { m.UsersId, m.RolesId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<EmployeeDetailModel> EmployeeDetails { get; set; }
    }
}
