namespace Exam_System.Data.Models
{
    public class ExamAnswer
    {
        public int Id { get; set; }
        public int ExamAttemptId { get; set; }
        public int QuestionId { get; set; }
        public int? SelectedChoiceId { get; set; }

        public ExamAttempt ExamAttempt { get; set; } = default!;
        public Question Question { get; set; } = default!;
        public Choice? SelectedChoice { get; set; }
    }
}
