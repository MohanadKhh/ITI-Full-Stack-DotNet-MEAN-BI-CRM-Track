namespace ITIApp.DAL
{
    public interface IGenericRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        //Task SaveChanges();
    }
}