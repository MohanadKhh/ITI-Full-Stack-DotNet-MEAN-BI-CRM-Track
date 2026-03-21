using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace Exam_System.Data.Repositories
{
    public class QuestionRepository : GeneralRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Question?> GetQuestionWithChoicesAsync(int id)
        {
            return await _dbSet
                .Include(q => q.Choices)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsByExamAsync(int examId)
        {
            return await _dbSet
                .Where(q => q.ExamId == examId)
                .Include(q => q.Choices)
                .ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetAllWithChoicesAsync()
        {
            return await _dbSet
                .Include(q => q.Choices)
                .ToListAsync();
        }
    }
}
