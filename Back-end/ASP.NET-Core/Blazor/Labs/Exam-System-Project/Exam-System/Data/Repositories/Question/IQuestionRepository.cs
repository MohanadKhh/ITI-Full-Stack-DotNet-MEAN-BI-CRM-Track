using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public interface IQuestionRepository : IGeneralRepository<Question>
    {
        Task<Question?> GetQuestionWithChoicesAsync(int id);
        Task<IEnumerable<Question>> GetQuestionsByExamAsync(int examId);
        Task<IEnumerable<Question>> GetAllWithChoicesAsync();
    }
}
