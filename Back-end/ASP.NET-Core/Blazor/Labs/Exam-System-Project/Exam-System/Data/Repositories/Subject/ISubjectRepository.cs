using Exam_System.Data.Models;
using Exam_System.Data.Repositories.General;

namespace Exam_System.Data.Repositories
{
    public interface ISubjectRepository : IGeneralRepository<Subject>
    {
        Task<Subject?> GetSubjectWithExamsAsync(int id);
        Task<IEnumerable<Subject>> GetAllWithExamsAsync();
    }
}
