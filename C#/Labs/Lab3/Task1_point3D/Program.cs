using System.Threading.Channels;

namespace Task1_point3D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Point3D Parse
            Point3D[] points = new Point3D[3];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point3D();
                double temp;
                Console.WriteLine($"Please Enter Point {i + 1} Values:");
                Console.Write("X: ");
                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    Console.WriteLine("Wrong value, X must be number");
                }
                points[i].X = temp;

                Console.Write("Y: ");
                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    Console.WriteLine("Wrong value, Y must be number");
                }
                points[i].Y = temp;

                Console.Write("Z: ");
                while (!double.TryParse(Console.ReadLine(), out temp))
                {
                    Console.WriteLine("Wrong value, Z must be number");
                }
                points[i].Z = temp;
            }


            foreach (var item in points)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Compare, Sort, Equals, Clone - Lab 6
            points.Sort();
            Console.WriteLine("\n\nPoints After Sorted: ");
            foreach (var item in points)
            {
                Console.WriteLine(item);
            }
            #endregion

            Point3D ponitClone = (Point3D)points[1].Clone();
            Console.WriteLine($"\n\nPonit Clone of points[2]: {ponitClone}");

            Console.WriteLine($"\n\nIs points[1] equals point Clone ? {points[1].Equals(ponitClone)}");

            Console.WriteLine($"Is points[1] == point Clone ? {points[1] == ponitClone}");

        }
    }
}
