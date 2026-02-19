using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DB_ITI.Models
{
    public class InsCourses
    {
        /***********************************************************/
        public int InsId { get; set; }
        public int CrsId { get; set; }
        public string? Evaluation {  get; set; }
        /***********************************************************/


        //Course and Instructor one to many relation
        public virtual Course Course { get; set; }
        public virtual Instructor Instuctor { get; set; }
    }
}
