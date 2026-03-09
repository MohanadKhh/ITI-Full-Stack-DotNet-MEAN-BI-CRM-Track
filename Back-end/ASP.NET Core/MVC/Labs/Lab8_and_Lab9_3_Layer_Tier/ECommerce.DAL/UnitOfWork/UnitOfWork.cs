namespace ECommerce.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        private readonly AppDBContext _context;

        public UnitOfWork(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            AppDBContext context)
        {
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
