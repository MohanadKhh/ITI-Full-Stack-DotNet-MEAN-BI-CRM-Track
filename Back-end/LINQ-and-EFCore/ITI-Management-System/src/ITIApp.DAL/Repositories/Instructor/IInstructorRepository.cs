namespace ITIApp.DAL
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Task<IEnumerable<Instructor>> GetAllWithRelationsAsync();
        Task<Instructor?> GetByIdWithRelationsAsync(int id);
    }
}