using ECommerce.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _context;

    // ✅ Lazy-initialized using the same _context
    private IProductRepository? _productRepository;
    private ICategoryRepository? _categoryRepository;

    public IProductRepository ProductRepository
        => _productRepository ??= new ProductRepository(_context);

    public ICategoryRepository CategoryRepository
        => _categoryRepository ??= new CategoryRepository(_context);

    public UnitOfWork(AppDBContext context)
    {
        _context = context;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}