using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _context.Products.Include(p => p.Category)
                    .Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Product?> GetByIdWithCategoryAsync(int id)
        {
            return await _context.Products
                        .Include(p => p.Category)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
