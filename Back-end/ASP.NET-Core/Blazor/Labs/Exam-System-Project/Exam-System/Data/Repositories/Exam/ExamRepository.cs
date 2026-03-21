using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace Exam_System.Data.Repositories
{
    public class ExamRepository : GeneralRepository<Exam>, IExamRepository
    {
        public ExamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Exam?> GetExamWithQuestionsAsync(int id)
        {
            return await _dbSet
                .Include(e => e.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Exam>> GetExamsBySubjectAsync(int subjectId)
        {
            return await _dbSet
                .Where(e => e.SubjectId == subjectId)
                .Include(e => e.Questions)
                .ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetAllWithQuestionsAsync()
        {
            return await _dbSet
                .Include(e => e.Questions)
                .ThenInclude(q => q.Choices)
                .ToListAsync();
        }
    }
}
