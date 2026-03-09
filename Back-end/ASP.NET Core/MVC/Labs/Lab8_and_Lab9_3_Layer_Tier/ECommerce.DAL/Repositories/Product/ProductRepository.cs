using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext context) : base(context)
        {
        }
        public IEnumerable<Product> GetAllWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product? GetByIdWithCategory(int id)
        {
            return _context.Products.Include(p => p.Category)
                                    .FirstOrDefault(p => p.Id == id);
        }
    }
}
