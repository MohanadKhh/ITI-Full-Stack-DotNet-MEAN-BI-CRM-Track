using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Task2_Duration
{
    internal class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public Duration()
        {
            Hours = Minutes = Seconds = 0;
        }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(int seconds)
        {
            Hours = seconds / 60 / 60;
            Minutes = (seconds / 60) % 60;
            Seconds = seconds % 60;
        }


        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public override bool Equals(object? obj)
        {
            var right = obj as Duration;
            if (right == null) return false;
            if (right.GetType() != this.GetType()) return false;
            return right.Hours == this.Hours && right.Minutes == this.Minutes && right.Seconds == this.Seconds;
        }

        public static Duration operator +(Duration left, Duration right)
        {
            int secondsTemp = left.Seconds + right.Seconds + (left.Hours + right.Hours) * 3600 + (left.Minutes + right.Minutes) * 60;
            return new Duration
            {
                Hours = secondsTemp / 60 / 60,
                Minutes = (secondsTemp / 60) % 60,
                Seconds = secondsTemp % 60,
            };
        }

        public static Duration operator +(Duration left, int right)
        {
            int secondsTemp = left.Seconds + right + (left.Hours * 3600) + (left.Minutes * 60);
            return new Duration
            {
                Hours = secondsTemp / 60 / 60,
                Minutes = (secondsTemp / 60) % 60,
                Seconds = secondsTemp % 60,
            };
        }

        public static Duration operator +(int left, Duration right)
        {
            int secondsTemp = left + right.Seconds + (right.Hours * 3600) + (right.Minutes * 60);
            return new Duration
            {
                Hours = secondsTemp / 60 / 60,
                Minutes = (secondsTemp / 60) % 60,
                Seconds = secondsTemp % 60,
            };
        }

        public static Duration operator ++(Duration duration)
        {
            duration.Minutes++;
            return new Duration
            {
                Hours = duration.Hours + duration.Minutes / 60,
                Minutes = duration.Minutes % 60,
                Seconds = duration.Seconds,
            };
        }
        public static Duration operator --(Duration duration)
        {
            duration.Minutes--;
            return new Duration
            {
                Hours = duration.Hours + duration.Minutes / 60,
                Minutes = (duration.Minutes + 60) % 60,
                Seconds = duration.Seconds,
            };
        }

        public static bool operator >(Duration left, Duration right)
        {
            if(left.Hours != right.Hours) return left.Hours > right.Hours;
            if(left.Minutes != right.Minutes) return left.Minutes > right.Minutes;
            return left.Seconds > right.Seconds;
        }

        public static bool operator <(Duration left, Duration right)
        {
            if(left.Hours != right.Hours) return left.Hours < right.Hours;
            if(left.Minutes != right.Minutes) return left.Minutes < right.Minutes;
            return left.Seconds < right.Seconds;
        }

        public static bool operator <=(Duration left, Duration right)
        {
            if(left.Hours != right.Hours) return left.Hours <= right.Hours;
            if(left.Minutes != right.Minutes) return left.Minutes <= right.Minutes;
            return left.Seconds <= right.Seconds;
        }

        public static bool operator >=(Duration left, Duration right)
        {
            if(left.Hours != right.Hours) return left.Hours >= right.Hours;
            if(left.Minutes != right.Minutes) return left.Minutes >= right.Minutes;
            return left.Seconds >= right.Seconds;
        } 
    }
}

