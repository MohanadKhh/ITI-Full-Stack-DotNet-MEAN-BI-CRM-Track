using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public interface IExamAttemptRepository : IGeneralRepository<ExamAttempt>
    {
        Task<IEnumerable<ExamAttempt>> GetAttemptsByUserAsync(string userId);
        Task<IEnumerable<ExamAttempt>> GetAttemptsByExamAsync(int examId);
        Task<ExamAttempt?> GetAttemptWithAnswersAsync(int id);
    }
}
