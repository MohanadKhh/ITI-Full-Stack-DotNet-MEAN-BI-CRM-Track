namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.Write("PLease Enter your message: ");
            str = Console.ReadLine();

            string strRev = string.Join(' ', str.Split(' ').Reverse());

            Console.WriteLine($"Reversed message: {strRev}");
        }
    }
}
