namespace Exam_System.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Points { get; set; } = 1;
        public int Order { get; set; }

        public Exam Exam { get; set; } = default!;
        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();
    }
}
