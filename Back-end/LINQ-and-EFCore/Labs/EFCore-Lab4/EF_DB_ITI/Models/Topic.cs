using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class Topic
    {
        /***********************************************************/
        public int Id { get; set; }
        public string? Name { get; set; }

        //Course Relation
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}