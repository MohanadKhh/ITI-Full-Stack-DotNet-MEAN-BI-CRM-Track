using System;
using System.Collections.Generic;
using System.Text;

namespace Dispaly_Find_Sort
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int TrackId { get; set; }

        static int idIdentity = 1;
        public Student()
        {
            Id = idIdentity++;
            FirstName = string.Empty;
            LastName = string.Empty;
        }

        public Student(string firstName, string lastName, int age, decimal salary, int trackId)
        {
            Id = idIdentity++;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            TrackId = trackId;
        }

        public override string ToString()
        {
            return $"Student: [Id: {Id}, Name: {FirstName + " " + LastName}, Age: {Age}, Salary: {Salary}, TrackId: {TrackId}]";
        }
    }

}
