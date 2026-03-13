using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIApp.DAL

{
    public class Instructor
    {
        /***********************************************************/
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string? Phone { get; set; }
       
        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        /***********************************************************/

        //Courses Relation one to many
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        //Instructor has many CourseSession
        public virtual ICollection<CourseSession> CourseSessions { get; set; } = new HashSet<CourseSession>();

        //Instructor work on one Department
        public virtual Department Department { get; set; }

        //Instructor manage one Department
        public virtual Department? ManagedDepartment { get; set; }
    }
}
