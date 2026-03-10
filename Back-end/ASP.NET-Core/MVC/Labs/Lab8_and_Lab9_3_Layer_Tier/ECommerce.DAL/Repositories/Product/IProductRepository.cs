namespace ECommerce.DAL
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        IEnumerable<Product> GetAllWithCategory();
        Product? GetByIdWithCategory(int id);
    }
}
