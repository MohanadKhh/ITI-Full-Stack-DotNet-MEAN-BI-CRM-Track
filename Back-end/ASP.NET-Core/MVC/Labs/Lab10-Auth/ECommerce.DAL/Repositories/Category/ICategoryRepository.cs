namespace ECommerce.DAL
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public IEnumerable<Category> GetAllByProducts();
        public Category? GetByIdWithProducts(int id);
    }
}
