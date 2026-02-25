using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Subject
    {
        public int Code {  get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Code = {Code}, Name = {Name}";
        }
    }
}
