using System.Linq;
using System.Runtime.Intrinsics.Arm;
using Task2;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Repository.GetEmployees();
            List<Department> departments = Repository.GetDepartments();

            Console.WriteLine("\n____________ Employees ____________\n");
            employees.PrintIEnumerable();

            Console.WriteLine("\n____________ Departements ____________\n");
            departments.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 1) ____________\n");
            var query1 = employees.Take(4);
            query1.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 2) ____________\n");
            var query2 = employees.Where(e => e.Salary > 5_000).Take(3);
            query2.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 3) ____________\n");
            var query3 = employees.TakeLast(4);
            query3.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 4) ____________\n");
            var query4 = employees.Skip(1).Take(2);
            query4.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 5) ____________\n");
            var query5 = employees.TakeWhile(e => e.Name.Length < 5);
            query5.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 6) ____________\n");
            EmpComparer empCmp = new EmpComparer();
            var query6 = employees.Distinct(empCmp);
            query6.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 7) ____________\n");
            var query7 = employees.Select(e => new { EmpId = e.Id, EmpName = e.Name });
            query7.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 8) ____________\n");
            var query8 = from emp in employees
                         select new { EmpId = emp.Id, EmpName = emp.Name };
            query8.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 9) ____________\n");
            var query9 = from emp in employees
                         join dep in departments
                         on emp.DeptId equals dep.DeptId
                         select new { EmpName = emp.Name, Department = dep.DeptName };
            query9.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 10) ____________\n");
            var query10 = employees.Join(departments, e => e.DeptId, d => d.DeptId, (emp, dep) => new { EmpName = emp.Name, Department = dep.DeptName });
            query10.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 11) ____________\n");
            var query11 = employees.GroupBy(e => e.DeptId); //////// Join By Dept Name /////////////////////////////////////////////////
            query11.PrintIEnumerableIGrouping();

            Console.WriteLine("\n____________ (Qu: 12) ____________\n"); //////// Join By Dept Name ///////////////////////////////////////////////////////////
            var query12 = from emp in employees
                          group emp by emp.DeptId;
            query12.PrintIEnumerableIGrouping();

            Console.WriteLine("\n____________ (Qu: 13) ____________\n");
            var query13 = employees.Min(e => e.Salary);
            Console.WriteLine($"Min Salary: {query13}");
            query13 = employees.Max(e => e.Salary);
            Console.WriteLine($"Max Salary: {query13}");
            query13 = employees.Average(e => e.Salary);
            Console.WriteLine($"Average Salary: {query13}");

            Console.WriteLine("\n____________ (Qu: 14) ____________\n");
            var query14 = employees.Where(e => e.Salary < employees.Average(e => e.Salary));
            query14.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 15) ____________\n");
            List<int> ints1 = new List<int> { 1, 1, 2, 3, 4, 5, 5 };
            List<int> ints2 = new List<int> { 4, 5, 6, 7, 8 };

            Console.WriteLine("Except:");
            var query15 = ints1.Except(ints2);
            foreach (var item in query15)
                Console.Write($"{item}  ");

            Console.WriteLine("\nUnion:");
            query15 = ints1.Union(ints2);
            foreach (var item in query15)
                Console.Write($"{item}  ");

            Console.WriteLine("\nConcat:");
            query15 = ints1.Concat(ints2);
            foreach (var item in query15)
                Console.Write($"{item}  ");

            Console.WriteLine("\nIntersect:");
            query15 = ints1.Intersect(ints2);
            foreach (var item in query15)
                Console.Write($"{item}  ");

            Console.WriteLine("\n____________ (Qu: 16) ____________\n");
            List<string> phNumbers = new List<string> { "01093382358", "0128401239", "01005584633" };
            List<string> names = new List<string> { "Ahmed", "Ali", "Sara" };

            var query16 = phNumbers.Zip(names);
            query16.PrintIEnumerable();
        }
    }
}
