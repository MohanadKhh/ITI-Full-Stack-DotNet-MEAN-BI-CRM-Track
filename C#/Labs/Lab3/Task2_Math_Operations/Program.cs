namespace Task2_Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Math Operations
            string continueRes;
            do
            {
                int first;
                decimal second;
                Console.Write("Please Enter first Number: ");
                while (!int.TryParse(Console.ReadLine(), out first)) ;
                Console.Write("Please Enter second Number: ");
                while (!decimal.TryParse(Console.ReadLine(), out second)) ;
                Console.WriteLine("Please Choose operations (+, -, *, /)");
                char op = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                switch (op)
                {
                    case '+':
                        Console.WriteLine($"{first} + {second} = {Math.add(first, second)}");
                        break;
                    case '-':
                        Console.WriteLine($"{first} - {second} = {Math.sub(first, second)}");
                        break;
                    case '*':
                        Console.WriteLine($"{first} * {second} = {Math.mult(first, second)}");
                        break;
                    case '/':
                        while (second == 0)
                        {
                            Console.WriteLine("can't divide by zero, please enter another number");
                            while (!decimal.TryParse(Console.ReadLine(), out second)) ;
                        }
                        Console.WriteLine($"{first} / {second} = {Math.div(first, second)}");
                        break;
                }
                Console.WriteLine("Are you need to continue? (y/n)");
                continueRes = Console.ReadLine().Trim().ToLower();
            }
            while (continueRes == "y" || continueRes == "yes");
            #endregion        }
        }
    }
}
