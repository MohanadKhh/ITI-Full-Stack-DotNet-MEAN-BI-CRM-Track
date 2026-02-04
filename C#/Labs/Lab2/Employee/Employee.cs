using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    internal class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public HireData HireData { get; set; }
        public SecurityLevel SecurityLevel { get; set; }

        public int CompareTo(Employee? other)
        {
            if(HireData.Year != other.HireData.Year) return HireData.Year.CompareTo(other.HireData.Year);
            else if (HireData.Month != other.HireData.Month) return HireData.Month.CompareTo(other.HireData.Month);
            return HireData.Day.CompareTo(other.HireData.Day);
        }

        //public Employee() { }
        //public Employee(int id, string name, decimal salary, Gender gender, HireData hireDate, SecurityLevel securityLevel)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Salary = salary;
        //    this.Gender = gender;
        //    this.HireData = hireDate;
        //    this.SecurityLevel = securityLevel;
        //}

        public string print()
        {
            return $"ID: {this.Id} | Name: {this.Name} | Salary: {this.Salary} EGP | Gender: {this.Gender} | HireData: {this.HireData} | SecurityLevel: {this.SecurityLevel}";
        }
    }
}
