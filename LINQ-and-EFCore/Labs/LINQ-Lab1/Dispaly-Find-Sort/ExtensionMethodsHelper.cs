using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dispaly_Find_Sort
{
    public static class ExtensionMethodsHelper
    {
        public static void printIEnumerable<T>(this IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<Student?> SortStudents(
            this IEnumerable<Student> students,
            int sortMethod, int sortWay)
        {
            return sortMethod switch
            {
                1 => sortWay == 1 ? students.OrderBy(s => s.FirstName) : students.OrderByDescending(s => s.FirstName),
                2 => sortWay == 1 ? students.OrderBy(s => s.Age) : students.OrderByDescending(s => s.Age),
                3 => sortWay == 1 ? students.OrderBy(s => s.Salary) : students.OrderByDescending(s => s.Salary),
                _=> students.DefaultIfEmpty(),
            };
        }
    }
}
