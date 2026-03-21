using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace Exam_System.Data.Repositories
{
    public class ExamAttemptRepository : GeneralRepository<ExamAttempt>, IExamAttemptRepository
    {
        public ExamAttemptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExamAttempt>> GetAttemptsByUserAsync(string userId)
        {
            return await _dbSet
                .Where(a => a.UserId == userId)
                .Include(a => a.Exam)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExamAttempt>> GetAttemptsByExamAsync(int examId)
        {
            return await _dbSet
                .Where(a => a.ExamId == examId)
                .Include(a => a.User)
                .ToListAsync();
        }

        public async Task<ExamAttempt?> GetAttemptWithAnswersAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Answers)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
