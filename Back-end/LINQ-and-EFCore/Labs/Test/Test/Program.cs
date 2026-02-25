using Task1.Context;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyContext db = new MyContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();


        }
    }
}
