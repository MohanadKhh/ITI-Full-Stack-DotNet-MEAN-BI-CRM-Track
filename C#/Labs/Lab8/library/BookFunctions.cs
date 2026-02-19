using System;
using System.Collections.Generic;
using System.Text;

namespace library
{
    internal class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }

        public static string GetAuthors(Book B)
        {
            return B.Authors;
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }
    }
}