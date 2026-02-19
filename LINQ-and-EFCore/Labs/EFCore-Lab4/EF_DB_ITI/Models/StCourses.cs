using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class StCourses
    {
        /***********************************************************/
        public int StId { get; set; }
        public int CrsId { get; set; }
        public int grade { get; set; }
        /***********************************************************/


        //Student and Course Relations
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
