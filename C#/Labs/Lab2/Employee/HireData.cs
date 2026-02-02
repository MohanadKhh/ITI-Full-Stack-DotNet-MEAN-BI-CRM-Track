using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    public class HireData
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireData(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}