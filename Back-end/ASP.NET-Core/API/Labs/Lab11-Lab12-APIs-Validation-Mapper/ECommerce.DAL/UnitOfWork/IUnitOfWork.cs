namespace ECommerce.DAL
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        void Save();
    }
}