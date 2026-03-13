using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIApp.DAL
{
    public class CourseSession
    {
        /***********************************************************/
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime SessionDate {  get; set; }

        [ForeignKey(nameof(Course))]
        public int CrsId { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InsId { get; set; }
        public bool IsDeleted { get; set; } = false;
        /***********************************************************/

        //CourseSession has one instructor
        public virtual Instructor Instructor { get; set; }

        //CourseSession has one Course
        public virtual Course Course { get; set; }

        //CourseSession has many CourseSessionAttendance
        public virtual ICollection<CourseSessionAttendance> CourseSessionAttendances { get; set; } = new HashSet<CourseSessionAttendance>();

    }
}
