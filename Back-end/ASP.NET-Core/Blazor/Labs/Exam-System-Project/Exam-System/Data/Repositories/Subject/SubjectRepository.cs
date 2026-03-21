using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace Exam_System.Data.Repositories
{
    public class SubjectRepository : GeneralRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Subject?> GetSubjectWithExamsAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Exams)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Subject>> GetAllWithExamsAsync()
        {
            return await _dbSet
                .Include(s => s.Exams)
                .ToListAsync();
        }
    }
}
