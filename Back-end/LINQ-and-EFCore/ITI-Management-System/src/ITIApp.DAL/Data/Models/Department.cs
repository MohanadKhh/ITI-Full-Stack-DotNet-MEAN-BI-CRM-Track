using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIApp.DAL

{
    public class Department
    {
        /***********************************************************/
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Location { get; set; }

        [ForeignKey(nameof(Manager))]
        public int? ManagerId { get; set; }
        /***********************************************************/

        //Course relation one to many
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        //Instructor Work in Department one to many
        public virtual ICollection<Instructor> Instuctors { get; set; } = new HashSet<Instructor>();

        //Instructor Manage Department one to one
        public virtual Instructor Manager { get; set; }
    }
}
