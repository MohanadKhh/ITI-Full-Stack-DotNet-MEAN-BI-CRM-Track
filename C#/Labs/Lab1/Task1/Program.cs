namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ARRSIZE = 100;
            int arrLen;
            int[] arr = new int[ARRSIZE];

            Console.Write("Please Enter size of array: ");
            arrLen = int.Parse(Console.ReadLine());

            for (int i = 0; i < arrLen; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write($"Array:\t");
            for (int i = 0; i < arrLen; i++)
            {
                Console.Write($"{arr[i]}\t");
            }

            if(arr.All(x => x == arr[0]))
            {
                Console.WriteLine($"\nMaximum distance between two same elements is: {arrLen - 2}");
                return;
            }

            int maxDiff = 0;
            for (int i = 0; i < arrLen - 1; i++)
            {
                for (int j = i + 1; j < arrLen; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        if(maxDiff < (j - i - 1))
                        {
                            maxDiff = j - i - 1;
                        }
                    }
                }
            }

            Console.WriteLine($"\nMaximum distance between two same elements is: {maxDiff}");
        }
    }
}
