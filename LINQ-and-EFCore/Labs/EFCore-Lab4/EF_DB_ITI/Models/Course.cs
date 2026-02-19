using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class Course
    {
        /***********************************************************/
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
        public int TopicId { get; set; }
        /***********************************************************/


        //Topic Relation One To Many
        public virtual Topic Topic { get; set; }


        //StudentCrs Relation One To Many
        public virtual ICollection<StCourses> StCourses { get; set; } = new HashSet<StCourses>();


        //StudentCrs Relation One To Many
        public virtual ICollection<InsCourses> InsCourses { get; set; } = new HashSet<InsCourses>();
    }
}
