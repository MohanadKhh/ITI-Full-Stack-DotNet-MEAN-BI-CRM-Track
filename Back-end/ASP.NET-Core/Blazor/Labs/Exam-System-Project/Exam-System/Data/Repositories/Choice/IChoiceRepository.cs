using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public interface IChoiceRepository : IGeneralRepository<Choice>
    {
        Task<IEnumerable<Choice>> GetChoicesByQuestionAsync(int questionId);
    }
}
