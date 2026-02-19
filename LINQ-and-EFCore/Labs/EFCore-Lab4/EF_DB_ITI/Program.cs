using EF_DB_ITI.Context;
using EF_DB_ITI.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_ITI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext db = new MyContext();

            //var departments = new List<Department>
            //{
            //    new Department { Name = "SD", Description = "Software Dev", Location = "Cairo", ManagerHireDate = DateTime.Now },
            //    new Department { Name = "UI", Description = "UI/UX", Location = "Giza", ManagerHireDate = DateTime.Now },
            //    new Department { Name = "Mobile", Description = "Mobile Apps", Location = "Alex", ManagerHireDate = DateTime.Now },
            //    new Department { Name = "Cloud", Description = "Cloud Services", Location = "Smart Village", ManagerHireDate = DateTime.Now },
            //    new Department { Name = "Data", Description = "Data Management", Location = "Nasr City", ManagerHireDate = DateTime.Now }
            //};

            //var students = new List<Student>
            //{
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
            //};

            //___________ Create ___________
            ////db.AddRange(departments);
            //db.AddRange(students);
            //db.SaveChanges();

            //___________ Delete ___________
            //db.Students.Where(s => s.Id > 15).ExecuteDelete();
            //var delStudents = db.Students.Where(s => s.Id > 10);
            //db.Students.RemoveRange(delStudents);
            //db.SaveChanges();

            //___________ Update ___________
            //db.Students.Where(s => s.Id == 5).ExecuteUpdate(s => s.SetProperty(s => s.FName, "Khakled"));
            //var upStudents = db.Students.Where(s => s.Id == 6).First();
            //upStudents.LName = "Khakled";
            //db.SaveChanges();

            //___________ Read ___________
            //foreach (var item in db.Students)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
