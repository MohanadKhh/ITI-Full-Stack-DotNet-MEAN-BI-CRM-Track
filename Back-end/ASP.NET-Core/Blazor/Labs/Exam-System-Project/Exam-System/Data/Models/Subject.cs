namespace Exam_System.Data.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
