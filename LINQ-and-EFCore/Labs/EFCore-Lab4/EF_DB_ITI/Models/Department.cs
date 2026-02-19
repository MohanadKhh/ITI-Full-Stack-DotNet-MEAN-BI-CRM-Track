using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class Department
    {
        /***********************************************************/
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? ManagerId { get; set; }
        public DateTime ManagerHireDate { get; set; }
        /***********************************************************/


        //Student relation one to many
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();


        //Instructor Work in Department one to many
        public virtual ICollection<Instructor> Instuctors { get; set; } = new HashSet<Instructor>();


        //Instructor Manage Department one to one
        public virtual Instructor Manager { get; set; }
    }
}
