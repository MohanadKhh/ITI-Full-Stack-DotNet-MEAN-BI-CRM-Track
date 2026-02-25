namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    FirstName="Ali",
                    LastName="Mohammed",
                    Subjects=new Subject[]
                    {
                        new Subject(){ Code=22, Name="EF"},
                        new Subject(){ Code=33, Name="UML"}
                    }
                },
                new Student()
                {
                    Id=2,
                    FirstName="Mona",
                    LastName="Gala",
                    Subjects=new Subject[]
                    {
                        new Subject(){ Code=22, Name="EF"},
                        new Subject(){ Code=34, Name="XML"},
                        new Subject(){ Code=25, Name="JS"}
                    }
                },
                new Student()
                {
                    Id=3,
                    FirstName="Yara",
                    LastName="Yousf",
                    Subjects=new Subject[]
                    {
                        new Subject(){ Code=22, Name="EF"},
                        new Subject(){ Code=25, Name="JS"}
                    }
                },
                new Student()
                {
                    Id=4,  // Changed from 1 to 4
                    FirstName="Ali",
                    LastName="Ali",
                    Subjects=new Subject[]
                    {
                        new Subject(){ Code=33, Name="UML"}
                    }
                }
            };
            Console.WriteLine("\n____________ (Qu: 1) ____________\n");

            Console.WriteLine("\n____ (Query 1) ____");
            var query1_1 = numbers.Distinct().Order();
            query1_1.PrintIEnumerable();

            Console.WriteLine("\n____ (Query 2) ____");
            var query1_2 = query1_1.Select(num => new { Number = num, Multiplication = num * num });
            query1_2.PrintIEnumerable();


            Console.WriteLine("\n____________ (Qu: 2) ____________\n");

            Console.WriteLine("\n____ (Query 1) ____");
            var query2_1 = names.Where(n => n.Length == 3);
            query2_1.PrintIEnumerable();

            Console.WriteLine("\n____ (Query 2) ____");
            var query2_2 = names.Where(n => n.ToLower().Contains('a')).OrderBy(n => n.Length);
            query2_2.PrintIEnumerable();

            Console.WriteLine("\n____ (Query 3) ____");
            var query2_3 = names.Take(2);
            query2_3.PrintIEnumerable();


            Console.WriteLine("\n____________ (Qu: 3) ____________\n");

            Console.WriteLine("\n____ (Query 1) ____");
            var query3_1 = students.Select(s => new { FullName = s.FirstName + " " + s.LastName, NoOfSubjects = s.Subjects.Length });
            query3_1.PrintIEnumerable();

            Console.WriteLine("\n____ (Query 2) ____");
            var query3_2 = students.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName).Select(s => s.FirstName + " " + s.LastName);
            query3_2.PrintIEnumerable();

            Console.WriteLine("\n____ (Query 3) ____");
            var query3_3 = students.SelectMany(st => st.Subjects, (st, subject) => new { StudentName = st.FirstName + " " + st.LastName, SubjectName = subject.Name });
            query3_3.PrintIEnumerable();

            Console.WriteLine("\n____ (Query 4) ____");
            var query3_4 = students.SelectMany(st => st.Subjects, (st, subject) => new { StudentName = st.FirstName + " " + st.LastName, SubjectName = subject.Name }).GroupBy(s => s.StudentName);
            foreach (var group in query3_4)
            {
                Console.WriteLine(group.Key);
                foreach(var item in group)
                    Console.WriteLine($"\t{item.SubjectName}");
            }
        }
    }
}
