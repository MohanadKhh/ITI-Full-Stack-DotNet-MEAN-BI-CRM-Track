using ITIApp.DAL;

namespace ITIApp.BLL
{
    public interface IInstructorManager
    {
        Task AddInstructorAsync(Instructor instructor);
        Task DeleteInstructorAsync(int id);
        Task EditInstructorAsync(int id, Instructor instructor);
        Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
        Task<Instructor> GetInstructorAsync(int id);
    }
}