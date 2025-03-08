﻿using DomainLayer.Models.Attendance;
using DomainLayer.Models.Department;
using DomainLayer.Models.Employee;
using DomainLayer.Models.Leave;
using DomainLayer.Models.Role;
using DomainLayer.Models.User;
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
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AttendanceModel> Attendances { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<LeaveModel> Leaves { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
