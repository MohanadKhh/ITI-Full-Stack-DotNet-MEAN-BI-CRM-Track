using LINQtoObject;
using System.Collections;
using Task2;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList books = SampleData.GetBooks();

            Console.WriteLine("\n____________ (Qu: 1) ____________\n");
            var query1 = books.Cast<Book>().Select(book => new { book.Title, book.Isbn });
            query1.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 2) ____________\n");
            var query2 = books.Cast<Book>().Where(b => b.Price > 25).Take(3);
            query2.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 3) ____________\n");
            var query3 = books.Cast<Book>().Select(b => b.Title + "\t" + b.Publisher.Name);
            query3.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 4) ____________\n");
            var query4 = books.Cast<Book>().Where(b => b.Price > 20).Count();
            Console.WriteLine($"Count of books that cost more than 20 = {query4}");

            Console.WriteLine("\n____________ (Qu: 5) ____________\n");
            var query5 = books.Cast<Book>().Select(b => new { b.Title, b.Price, SubjectName = b.Subject.Name }).OrderBy(b => b.SubjectName)
                                            .ThenByDescending(b => b.Price);
            query5.PrintIEnumerable();

            Console.WriteLine("\n____________ (Qu: 6.1) ____________\n");
            var query6_1 = books.Cast<Book>().GroupBy(b => b.Subject.Name);
            query6_1.PrintIEnumerableIGrouping();

            Console.WriteLine("\n____________ (Qu: 6.2) ____________\n"); ////////need another way with method syntax
            var query6_2 = from b in books.Cast<Book>()
                           group b by b.Subject.Name;
            query6_2.PrintIEnumerableIGrouping();


            Console.WriteLine("\n____________ (Qu: 7) ____________\n");
            var query7 = books.Cast<Book>().GroupBy(b => new { Publisher = b.Publisher.Name, Subject = b.Subject.Name });

            query7.PrintIEnumerableIGrouping();
        }
    }
}
