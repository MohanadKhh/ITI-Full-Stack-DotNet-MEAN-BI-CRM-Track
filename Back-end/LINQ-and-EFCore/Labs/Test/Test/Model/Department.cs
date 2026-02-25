using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task1.Model
{
    public class Department
    {
        public int Id { get; set; }

        [MinLength(2), MaxLength(25)]
        public string Name { get; set; }

        //NavProperty - One to many Relation
        public virtual ICollection<Student> Students { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
