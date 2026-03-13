namespace ITIApp.DAL
{
    public class Student
    {
        /***********************************************************/
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        /***********************************************************/

        //Nav Property of Student Courses table
        public virtual ICollection<StCourses> StCourses { get; set; } = new HashSet<StCourses>();

        //Student has many CourseSessionAttendance
        public virtual ICollection<CourseSessionAttendance> CourseSessionAttendances { get; set; } = new HashSet<CourseSessionAttendance>();
    }
}
