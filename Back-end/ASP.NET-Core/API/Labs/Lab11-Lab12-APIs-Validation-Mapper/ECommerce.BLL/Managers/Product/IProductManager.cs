using ECommerce.DAL;

namespace ECommerce.BLL
{
    public interface IProductManager
    {
        void AddProduct(ProductCreateVM productCreateVM);
        void DeleteProduct(int id);
        public Product? EditProduct(int id, ProductEditVM productEditVM);
        IEnumerable<ProductReadVM> GetAllProducts();
        ProductReadVM? GetProduct(int id);
        public IEnumerable<ProductReadVM> GetProductsByCategoryId(int categoryId);
    }
}