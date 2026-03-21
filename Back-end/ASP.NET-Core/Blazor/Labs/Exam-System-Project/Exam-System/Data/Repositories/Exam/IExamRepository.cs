using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public interface IExamRepository : IGeneralRepository<Exam>
    {
        Task<Exam?> GetExamWithQuestionsAsync(int id);
        Task<IEnumerable<Exam>> GetExamsBySubjectAsync(int subjectId);
        Task<IEnumerable<Exam>> GetAllWithQuestionsAsync();
    }
}
