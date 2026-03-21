using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public class ChoiceRepository : GeneralRepository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Choice>> GetChoicesByQuestionAsync(int questionId)
        {
            return await FindAsync(c => c.QuestionId == questionId);
        }
    }
}
