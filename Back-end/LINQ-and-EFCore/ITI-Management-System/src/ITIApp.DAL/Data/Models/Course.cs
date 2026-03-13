using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIApp.DAL
{
    public class Course
    {
        /***********************************************************/
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }
        public bool IsDeleted { get; set; } = false;
        /***********************************************************/

        //Course han one instructor
        public virtual Instructor Instructor { get; set; }

        //Course has many student Courses
        public virtual ICollection<StCourses> StCourses { get; set; } = new HashSet<StCourses>();

        //Course has one department
        public virtual Department Department { get; set; }

        //Course has many CourseSession
        public virtual ICollection<CourseSession> CourseSessions { get; set; } = new HashSet<CourseSession>();


    }
}
