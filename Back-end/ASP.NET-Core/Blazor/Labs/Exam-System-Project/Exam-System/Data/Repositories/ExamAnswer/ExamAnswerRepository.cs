using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public class ExamAnswerRepository : GeneralRepository<ExamAnswer>, IExamAnswerRepository
    {
        public ExamAnswerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExamAnswer>> GetAnswersByAttemptAsync(int attemptId)
        {
            return await FindAsync(a => a.ExamAttemptId == attemptId);
        }

        public async Task<IEnumerable<ExamAnswer>> GetAnswersByQuestionAsync(int questionId)
        {
            return await FindAsync(a => a.QuestionId == questionId);
        }
    }
}
