namespace ECommerce.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public T? GetById(int id);

        public void Add(T entity);

        public void Delete(int id);
    }
}
