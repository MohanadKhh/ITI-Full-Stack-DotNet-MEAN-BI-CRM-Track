using System.Text;

namespace Task2
{
    public static class ExtensionMethodsHelper
    {
        public static void PrintIEnumerable<TSource>(this IEnumerable<TSource> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static string ToStringIEnumerable<TSource>(this IEnumerable<TSource> list)
        {
            StringBuilder strB = new StringBuilder();
            foreach (var item in list)
            {
                strB.Append(item);
            }
            return strB.ToString();
        }

        public static void PrintIEnumerableIGrouping<TKey, TSource>(this IEnumerable<IGrouping<TKey, TSource>> groupOfList)
        {
            foreach (var list in groupOfList)
            {
                Console.WriteLine($"\nKey: {list.Key}");
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
