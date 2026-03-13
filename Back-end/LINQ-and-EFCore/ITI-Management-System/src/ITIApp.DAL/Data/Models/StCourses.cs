using System.ComponentModel.DataAnnotations.Schema;

namespace ITIApp.DAL

{
    public class StCourses
    {
        /***********************************************************/
        [ForeignKey(nameof(Student))]
        public int StId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CrsId { get; set; }
        public bool IsDeleted { get; set; } = false;
        /***********************************************************/


        //Student and Course Relations
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
