using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIApp.DAL
{
    public class CourseSessionAttendance
    {
        /***********************************************************/
        [Key]
        public int Id { get; set; }
        public int Grade { get; set; }
        public string? Notes { get; set; }

        [ForeignKey(nameof(CourseSession))]
        public int CrsSessionId { get; set; }

        [ForeignKey(nameof(Student))]
        public int StId { get; set; }
        /***********************************************************/

        //CourseSessionAttendance has one Student
        public virtual Student Student { get; set; }

        //CourseSessionAttendance has one Course
        public virtual CourseSession CourseSession { get; set; }
    }
}
