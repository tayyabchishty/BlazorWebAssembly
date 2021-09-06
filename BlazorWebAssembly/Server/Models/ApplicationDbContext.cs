using BlazorWebAssembly.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Admin" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Finance" });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Jhon",
                LastName = "Hasting",
                Email = "jhon@gmail.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartmentId=1,
                PhotoPath="images/jhon.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Carter",
                LastName = "hugh",
                Email = "carter@gmail.com",
                DateOfBirth = new DateTime(1982, 11, 5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/carter.jpg"
            });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Julie",
                LastName = "James",
                Email = "julie@gmail.com",
                DateOfBirth = new DateTime(1991, 5, 5),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/julie.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sam",
                LastName = "Ali",
                Email = "sam@gmail.com",
                DateOfBirth = new DateTime(1990, 5, 5),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/sam.jpg"
            });
        }
    }
}
