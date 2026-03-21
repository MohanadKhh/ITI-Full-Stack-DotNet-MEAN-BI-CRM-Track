using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public interface IExamAnswerRepository : IGeneralRepository<ExamAnswer>
    {
        Task<IEnumerable<ExamAnswer>> GetAnswersByAttemptAsync(int attemptId);
        Task<IEnumerable<ExamAnswer>> GetAnswersByQuestionAsync(int questionId);
    }
}
