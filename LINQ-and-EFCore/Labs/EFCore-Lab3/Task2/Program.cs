using Task1.Context;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext db = new MyContext();

            var students = db.Students;

            #region QU(1)
            Console.WriteLine("\n____________ Qu(1) ____________\n");
            var query1 = from s in students
                         select s;
            foreach (var student in query1)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(2)
            Console.WriteLine("\n____________ Qu(2) ____________\n");
            var query2 = students.Select(s => s);
            foreach (var student in query2)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(3)
            Console.WriteLine("\n____________ Qu(3) ____________\n");
            var query3 = from s in students
                         where s.Age > 30
                         select s;
            foreach (var student in query3)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(4)
            Console.WriteLine("\n____________ Qu(4) ____________\n");
            var query4 = students.Where(s => s.Salary < 5000);
            foreach (var student in query4)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(5)
            Console.WriteLine("\n____________ Qu(5) ____________\n");
            var query5 = from s in students
                         where s.DepartmentId == 1 && s.Salary > 4000
                         orderby s.Name descending
                         select s;
            foreach (var student in query5)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(6)
            Console.WriteLine("\n____________ Qu(6) ____________\n");
            var query6 = students.Where(s => s.DepartmentId == 1 && s.Name.ToLower().Contains("m".ToLower()))
                                .OrderBy(s => s.Salary);
            foreach (var student in query6)
            {
                Console.WriteLine(student);
            }
            #endregion

            #region QU(7)
            try
            {
                Console.WriteLine("\n____________ Qu(7.1) ____________\n");
                var query7_1 = students.Where(s => s.Salary > 5000).First();
                Console.WriteLine(query7_1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n____________ Qu(7.2) ____________\n");
            var query7_2 = students.Where(s => s.Salary > 5000).FirstOrDefault();
            Console.WriteLine(query7_2);
            #endregion


            #region QU(8)
            try
            {
                Console.WriteLine("\n____________ Qu(8.1) ____________\n");
                var query8_1 = students.Where(s => s.DepartmentId == 3).OrderBy(s => s.Id).Last();  //must to use OrderBy with last as SQL only use Select TOP(1)
                Console.WriteLine(query8_1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n____________ Qu(8.2) ____________\n");
            var query8_2 = students.Where(s => s.DepartmentId == 3).OrderBy(s => s.Id).LastOrDefault();
            Console.WriteLine(query8_2);
            #endregion


            #region QU(9)
            try
            {
                Console.WriteLine("\n____________ Qu(9.1) ____________\n");
                var query9_1 = students.Where(s => s.Age == 25).Single();
                Console.WriteLine(query9_1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n____________ Qu(9.2) ____________\n");
            var query9_2 = students.Where(s => s.Age == 25).SingleOrDefault();
            Console.WriteLine(query9_2);
            #endregion

            #region QU(10)
            try
            {
                Console.WriteLine("\n____________ Qu(10.1) ____________\n");
                var query10_1 = students.Where(s => s.DepartmentId == 8).Single();
                Console.WriteLine(query10_1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\n____________ Qu(10.2) ____________\n");
            var query10_2 = students.Where(s => s.DepartmentId == 8).SingleOrDefault();
            Console.WriteLine(query10_2);
            #endregion
        }
    }
}
