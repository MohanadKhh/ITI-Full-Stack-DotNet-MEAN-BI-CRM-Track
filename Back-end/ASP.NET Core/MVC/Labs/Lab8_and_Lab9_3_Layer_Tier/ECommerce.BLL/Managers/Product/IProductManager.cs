namespace ECommerce.BLL
{
    public interface IProductManager
    {
        void AddProduct(ProductCreateVM productCreateVM, string ImagePath);
        void DeleteProduct(int id);
        void EditProduct(ProductEditVM productEditVM, string? ImagePath);
        IEnumerable<ProductReadVM> GetAllProducts();
        public IEnumerable<CategoryVM> GetCategoriesList();
        ProductReadVM? GetProduct(int id);
        ProductCreateVM GetProductCreateView();
        ProductsDropdownVM GetProductDropDownVM(int categoryId);
        ProductEditVM? GetProductEditVMById(int id);
    }
}