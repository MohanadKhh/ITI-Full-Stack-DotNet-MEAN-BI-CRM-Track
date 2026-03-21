namespace Exam_System.Data.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public Question Question { get; set; } = default!;
        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();
    }
}
