namespace Exam_System.Data.Models
{
    public class ExamAttempt
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? FinishedAt { get; set; }
        public int Score { get; set; }

        public Exam Exam { get; set; } = default!;
        public ApplicationUser User { get; set; } = default!;
        public ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();
    }
}
