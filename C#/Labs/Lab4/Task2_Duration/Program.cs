namespace Task2_Duration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration duration = new Duration();
            Duration duration2 = new Duration(5, 10, 23);
            Duration duration3 = new Duration(3600);
            Duration duration4 = new Duration(7800);
            Duration duration5 = new Duration(666);
            Duration duration6 = new Duration(666);

            Console.WriteLine($"Duration 1: {duration}");
            Console.WriteLine($"Duration 2 of 5H 10M 23S: {duration2}");
            Console.WriteLine($"Duration 3 of 3600: {duration3}");
            Console.WriteLine($"Duration 4 of 7800: {duration4}");
            Console.WriteLine($"Duration 5 of 666: {duration5}\n");

            Console.WriteLine($"Is Duration 5 equal Duration 6 ? {duration5.Equals(duration6)}");
            Console.WriteLine($"Is Duration 5 equal Duration 2 ? {duration5.Equals(duration2)}\n");

            Console.WriteLine($"Duration 2 + Duration 3 = {duration2 + duration3}");
            Console.WriteLine($"Duration 2 + 7800 = {duration2 + 7800}");
            Console.WriteLine($"666 + Duration 3 = {666 + duration3}");
            Console.WriteLine($"Duration 2 ++ = {duration2++}");
            Console.WriteLine($"Duration 4 -- = {duration4--}\n");

            Console.WriteLine($"Is Duration 5 > Duration 3 ? {duration5 > duration3}");
            Console.WriteLine($"Is Duration 3 < Duration 2 ? {duration3 < duration2}");
            Console.WriteLine($"Is Duration 4 >= Duration 1 ? {duration4 >= duration}");
            Console.WriteLine($"Is Duration 2 <= Duration 5 ? {duration2 <= duration5}");

        }
    }
}
