using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context) { }

        public IEnumerable<Category> GetAllByProducts()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }

        public Category? GetByIdWithProducts(int id)
        {
            return _context.Categories.Include(c => c.Products)
                                    .FirstOrDefault(c => c.Id == id);
        }
    }
}
