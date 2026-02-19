using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class Instructor
    {
        /***********************************************************/
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Degree { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }
        /***********************************************************/


        //InsCourses Relation one to many
        public virtual ICollection<InsCourses> InsCourses { get; set; } = new HashSet<InsCourses>();


        //Department Relation one to many work on
        public virtual Department Department { get; set; }


        //Department that Instructor manage one to one
        public virtual Department? ManagedDepartment { get; set; }
    }
}
