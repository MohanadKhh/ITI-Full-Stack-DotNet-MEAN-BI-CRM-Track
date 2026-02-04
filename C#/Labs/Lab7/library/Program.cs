namespace library
{
    public delegate string DelegateName(Book book);
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("978-1", "Clean Code", "Robert C. Martin",
                               new DateTime(2008, 8, 1), 450));

            books.Add(new Book("978-2", "Design Patterns", "GoF",
                               new DateTime(1994, 10, 21), 600));

            books.Add(new Book("978-3", "C# in Depth", "Jon Skeet",
                               new DateTime(2019, 3, 23), 500));


            DelegateName del = BookFunctions.GetPrice;
            DelegateName del2 = BookFunctions.GetAuthors;
            DelegateName del3 = BookFunctions.GetTitle;


            Console.WriteLine("User Defined Delegate Datatype (Title)");
            LibraryEngine.ProcessBooks(books, del3);

            Console.WriteLine("\nUser Defined Delegate Datatype (Price)");
            LibraryEngine.ProcessBooks(books, del);

            Console.WriteLine("\nUser Defined Delegate Datatype (Authors)");
            LibraryEngine.ProcessBooks(books, del2);

            Console.WriteLine("\nAnonymous Function (ISBN)");
            LibraryEngine.ProcessBooks(books, b => b.ISBN);

            //Func<Book, string> fPublicationDate = b => b.PublicationDate.ToString();

            //Console.WriteLine("\nLambda Expression (Publication Date)");
            //LibraryEngine.ProcessBooks(books, fPublicationDate);

        }
    }
}
