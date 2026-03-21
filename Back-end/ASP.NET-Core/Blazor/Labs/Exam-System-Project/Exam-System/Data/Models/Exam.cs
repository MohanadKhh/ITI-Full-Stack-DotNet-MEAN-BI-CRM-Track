namespace Exam_System.Data.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }

        public Subject Subject { get; set; } = default!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<ExamAttempt> Attempts { get; set; } = new List<ExamAttempt>();
    }
}
