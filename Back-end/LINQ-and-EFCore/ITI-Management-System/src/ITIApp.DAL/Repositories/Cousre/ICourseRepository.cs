namespace ITIApp.DAL
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<Course>> GetAllWithRelationsAsync();
        Task<Course?> GetByIdWithRelationsAsync(int id);
        Task DeleteCourseAsync(int id);
    }
}