using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task1.Model
{
    public class Student
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        public int? Age { get; set; }
        public decimal? Salary { get; set; }
        public int DepartmentId { get; set; }

        //NavProperty - One to many Relation
        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Salary: {Salary}, DeptId: {DepartmentId}";
        }
    }
}
