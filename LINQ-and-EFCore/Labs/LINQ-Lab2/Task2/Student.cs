using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] Subjects { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {FirstName} {LastName}, Subjects = [{Subjects.ToStringIEnumerable()}]";
        }

    }
}
