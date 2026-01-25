using System.Diagnostics;

namespace Task3
{
    internal class Program
    {
        const int NUM = 99999999;
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            int counter = 0;

            int getDigitsNum(int num)
            {
                int digits = 0;
                while (num > 0)
                {
                    digits++;
                    num /= 10;
                }
                return digits;
            }

            int getOnes(int num)
            {
                int counter = 0;
                while (num > 0)
                {
                    if (num % 10 == 1)
                    {
                        counter++;
                    }
                    num /= 10;
                }
                return counter;
            }


            //First Way
            Console.WriteLine("First Way:");
            s.Start();

            for (int i = 1; i <= NUM; i++)
            {
                string str = i.ToString();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        counter++;
                    }
                }
            }

            s.Stop();
            Console.WriteLine($"Number of 1's between 0 and {NUM} is: {counter}");
            Console.WriteLine(s.Elapsed);


            //Second Way
            Console.WriteLine("\n\nSecond Way:");
            counter = 0;
            s = new Stopwatch();
            s.Start();

            for (int i = 1; i <= NUM; i++)
                counter += getOnes(i);

            s.Stop();
            Console.WriteLine($"Number of 1's between 0 and {NUM} is: {counter}");
            Console.WriteLine(s.Elapsed);


            //Third Way
            Console.WriteLine("\n\nThird Way:");
            s = new Stopwatch();
            s.Start();

            int digits = getDigitsNum(NUM);
            counter = digits * (int)Math.Pow(10, digits - 1);

            s.Stop();
            Console.WriteLine($"Number of 1's between 0 and {NUM} is: {counter}");
            Console.WriteLine(s.Elapsed);
        }
    }
}
