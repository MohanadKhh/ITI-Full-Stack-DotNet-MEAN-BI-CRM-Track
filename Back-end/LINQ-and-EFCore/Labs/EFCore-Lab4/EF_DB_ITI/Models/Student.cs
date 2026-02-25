using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class Student
    {
        /***********************************************************/
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public int Age { get; set; }
        public string? Adddress { get; set; }
        public int DeptId { get; set; }
        public int? SuperID { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {FName} {LName}, Age: {Age}, DeptId: {DeptId}, SuperId: {SuperID}";
        }
        /***********************************************************/
        
        
        //StCourses Relation
        public virtual ICollection<StCourses> StCourses {  get; set; } = new HashSet<StCourses>();


        //Department Relation One to Many
        public virtual Department Department { get; set; }


        //Self Subervisor Relation
        public virtual Student Supervisor { get; set; }
        public virtual ICollection<Student> Students {  get; set; } = new HashSet<Student>();
    }
}
