namespace Dispaly_Find_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = Repository.GetStudents();
            List<Track> tracks = Repository.GetTracks();

            #region Display

            Console.WriteLine("\n_______________ (Qu: 1) _______________\n");
            var query1 = from s in students
                         select s;
            query1.printIEnumerable();

            Console.WriteLine("\n_______________ (Qu: 2) _______________\n");
            var query2 = students.Where(s => s != null);
            query2.printIEnumerable();

            Console.WriteLine("\n_______________ (Qu: 3) _______________\n");
            var query3 = from s in students
                         where s.Age > 30
                         select s;
            query3.printIEnumerable();

            Console.WriteLine("\n_______________ (Qu: 4) _______________\n");
            var query4 = students.Where(s => s.Salary < 5_000);
            query4.printIEnumerable();

            Console.WriteLine("\n_______________ (Qu: 5) _______________\n");
            var query5 = from s in students
                         where s.TrackId == 1 && s.Salary > 4_000
                         orderby s.FirstName descending
                         select s;
            query5.printIEnumerable();

            Console.WriteLine("\n_______________ (Qu: 6) _______________\n");
            var query6 = students.Where(s => s.TrackId == 1 && s.FirstName.ToLower().Contains("m".ToLower()))
                                   .OrderBy(s => s.Salary);
            query6.printIEnumerable();

            #endregion

            #region Find

            Console.WriteLine("\n_______________ (Qu: 7.1) _______________\n");
            try
            {
                var query7_1 = students.First(s => s.Salary > 5_000);
                Console.WriteLine(query7_1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n_______________ (Qu: 7.2) _______________\n");
            var query7_2 = students.FirstOrDefault(s => s.Salary > 5_000);
            Console.WriteLine(query7_2);

            Console.WriteLine("\n_______________ (Qu: 8.1) _______________\n");
            try
            {
                var query8_1 = students.Last(s => s.TrackId == 1);
                Console.WriteLine(query8_1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n_______________ (Qu: 8.2) _______________\n");
            var query8_2 = students.LastOrDefault(s => s.TrackId == 1);
            Console.WriteLine(query8_2);

            Console.WriteLine("\n_______________ (Qu: 9.1) _______________\n");
            try
            {
                var query9_1 = students.Single(s => s.Age == 25);
                Console.WriteLine(query9_1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n_______________ (Qu: 9.2) _______________\n");
            var query9_2 = students.SingleOrDefault(s => s.Age == 25);
            Console.WriteLine(query9_2);

            Console.WriteLine("\n_______________ (Qu: 10.1) _______________\n");
            try
            {
                var query10_1 = students.Single(s => s.TrackId == 8);
                Console.WriteLine(query10_1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n_______________ (Qu: 10.2) _______________\n");
            var query10_2 = students.SingleOrDefault(s => s.TrackId == 8);
            Console.WriteLine(query10_2);

            Console.WriteLine("\n_______________ (Qu: 11.1) _______________\n");
            try
            {
                var query11_1 = students.ElementAt(4);
                Console.WriteLine(query11_1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n_______________ (Qu: 11.2) _______________\n");
            try
            {
                var query11_2 = students.ElementAt(200);
                Console.WriteLine(query11_2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            #endregion

            Console.WriteLine("\n_______________ (Qu: 12) _______________\n");

            int sortMethod;
            int sortWay;
            string input;

            Console.WriteLine("Please Enter What do you need Order By ?");
            do
            {
                Console.WriteLine("Please write only 1 or 2 or 3\n1.Name   2.Age   3.Salary");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out sortMethod) || sortMethod<0 || sortMethod>4);
            
            Console.WriteLine("Please Enter What way do you need Order By ?");
            do
            {
                Console.WriteLine("Please write only 1 or 2\n1.Ascending   2.Desending");
                input = Console.ReadLine();
            }
            while (! int.TryParse(input, out sortWay) || sortWay < 0 || sortWay > 3);

            Func<int, int, IEnumerable<Student>> func = (sortMethod, sortWay) =>
            {
                switch (sortMethod)
                {
                    case 1:
                        if (sortWay == 1)
                            return students.OrderBy(s => s.FirstName);
                        return students.OrderByDescending(s => s.FirstName);
                        break;

                    case 2:
                        if (sortWay == 1)
                            return students.OrderBy(s => s.Age);
                        return students.OrderByDescending(s => s.Age);
                        break;

                    case 3:
                        if (sortWay == 1)
                            return students.OrderBy(s => s.Salary);
                        return students.OrderByDescending(s => s.Salary);
                        break;
                    
                    default:
                        return null;
                }
            };

            students.SortStudents(sortMethod, sortWay).printIEnumerable();

        }
    }
}
