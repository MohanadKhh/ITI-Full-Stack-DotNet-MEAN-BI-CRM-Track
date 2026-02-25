using Microsoft.EntityFrameworkCore;
using Task1.Context;
using Task1.Model;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext db = new MyContext();

            #region Creating DB
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            #endregion

            #region QU(1) Create Department and add them
            //Department d1 = new Department { Name = "SD" };
            //Department d2 = new Department { Name = "UI" };
            //Department d3 = new Department { Name = "Mobile" };
            //Department d4 = new Department { Name = "Cloud" };
            //Department d5 = new Department { Name = "Data Managment" };

            //db.AddRange(d1, d2, d3, d4, d5);
            //db.SaveChanges();
            #endregion

            #region QU(2) Create Students and add them
            //Student s1 = new Student { Name = "Ali", Age = 20, Salary = 3000, DepartmentId = 1 };
            //Student s2 = new Student { Name = "Omar", Age = 21, Salary = 3200, DepartmentId = 2 };
            //Student s3 = new Student { Name = "Hassan", Age = 22, Salary = 3500, DepartmentId = 3 };
            //Student s4 = new Student { Name = "Youssef", Age = 23, Salary = 2800, DepartmentId = 4 };
            //Student s5 = new Student { Name = "Karim", Age = 24, Salary = 4000, DepartmentId = 5 };

            //Student s6 = new Student { Name = "Ahmed", Age = 35, Salary = 3100, DepartmentId = 1 };
            //Student s7 = new Student { Name = "Mostafa", Age = 32, Salary = 3300, DepartmentId = 2 };
            //Student s8 = new Student { Name = "Ibrahim", Age = 36, Salary = 3600, DepartmentId = 3 };
            //Student s9 = new Student { Name = "Mahmoud", Age = 23, Salary = 2900, DepartmentId = 4 };
            //Student s10 = new Student { Name = "Tarek", Age = 24, Salary = 4100, DepartmentId = 5 };

            //db.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);
            //db.SaveChanges();
            #endregion

            #region QU(3)
            Console.WriteLine("\n____________ Qu(3) ____________\n");
            var query3 = db.Students;
            foreach (var student in query3)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(4)
            Console.WriteLine("\n____________ Qu(4) ____________\n");
            var query4 = db.Departments;
            foreach (var dept in query4)
            {
                Console.WriteLine(dept);
            }
            #endregion

            #region QU(5)
            Console.WriteLine("\n____________ Qu(5.1 Eager loading) ____________\n");
            var query5 = db.Students.Include(s => s.Department);
            foreach (var dept in query5)
            {
                Console.WriteLine($"{dept}\t{dept.Department}");
            }

            Console.WriteLine("\n____________ Qu(5.2 Lazy Loading) ____________\n");
            var query5_2 = db.Students.ToList();
            foreach (var dept in query5_2)
            {
                Console.WriteLine($"{dept}\t{dept.Department}");
            }
            #endregion

            #region QU(6)
            Console.WriteLine("\n____________ Qu(6) ____________\n");
            var query6 = db.Students.Include(s => s.Department).Where(s => s.DepartmentId == 1);
            foreach (var dept in query6)
            {
                Console.WriteLine($"{dept}\t{dept.Department}");
            }
            #endregion

            #region QU(7)
            Console.WriteLine("\n____________ Qu(7) ____________\n");
            var query7 = db.Students.Where(s => s.DepartmentId == 1).OrderByDescending(s => s.Name);
            foreach (var dept in query7)
            {
                Console.WriteLine($"{dept}");
            }
            #endregion
        }
    }
}
