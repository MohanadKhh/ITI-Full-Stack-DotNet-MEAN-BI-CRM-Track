using System;
using System.Collections.Generic;
using System.Text;

namespace library
{
    internal class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, DelegateName del)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(del(B));
            }
        }
    }
}


    