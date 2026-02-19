using EF_DB_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace EF_DB_ITI.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=EF_Lab4_TIT_DB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "SD", Description = "Software Dev", Location = "Cairo", ManagerHireDate = new DateTime(2025, 1, 2) },
                new Department { Id = 2, Name = "Mobile", Description = "Mobile Apps", Location = "Alex", ManagerHireDate = new DateTime(2025, 1, 23) },
                new Department { Id = 3, Name = "Cloud", Description = "Cloud Services", Location = "Smart Village", ManagerHireDate = new DateTime(2025, 4, 12) },
                new Department { Id = 4, Name = "UI", Description = "UI/UX", Location = "Giza", ManagerHireDate = new DateTime(2025, 6, 1) },
                new Department { Id = 5, Name = "Data", Description = "Data Management", Location = "Nasr City", ManagerHireDate = new DateTime(2025, 5, 5) }
                );

            //modelBuilder.Entity<Student>().HasData(
            //    new Student { FName = "Ali", LName = "Hassan", Age = 20, Adddress = "Cairo", DeptId = 1 },
            //    new Student { FName = "Omar", LName = "Ahmed", Age = 21, Adddress = "Giza", DeptId = 2 },
            //    new Student { FName = "Youssef", LName = "Mahmoud", Age = 22, Adddress = "Alex", DeptId = 3 },
            //    new Student { FName = "Karim", LName = "Mostafa", Age = 23, Adddress = "Cairo", DeptId = 4 },
            //    new Student { FName = "Ibrahim", LName = "Tarek", Age = 24, Adddress = "Giza", DeptId = 5 },

            //    new Student { FName = "Hossam", LName = "Adel", Age = 20, Adddress = "Alex", DeptId = 1 },
            //    new Student { FName = "Amr", LName = "Khaled", Age = 21, Adddress = "Cairo", DeptId = 2 },
            //    new Student { FName = "Mostafa", LName = "Saeed", Age = 22, Adddress = "Giza", DeptId = 3 },
            //    new Student { FName = "Mahmoud", LName = "Fathy", Age = 23, Adddress = "Alex", DeptId = 4 },
            //    new Student { FName = "Tamer", LName = "Nabil", Age = 24, Adddress = "Cairo", DeptId = 5 }
            //    );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<InsCourses> InsCourses { get; set; }
        public virtual DbSet<StCourses> StCourses { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
    }
}
