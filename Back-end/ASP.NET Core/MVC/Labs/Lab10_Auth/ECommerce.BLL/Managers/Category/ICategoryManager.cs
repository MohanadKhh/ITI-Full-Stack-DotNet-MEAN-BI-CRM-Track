namespace ECommerce.BLL
{
    public interface ICategoryManager
    {
        void AddCategory(CategoryVM categoryVM);
        void DeleteCategory(int id);
        void EditCategory(CategoryVM categoryVM);
        IEnumerable<CategoryVM> GetAllCategories();
        CategoryVM GetCategory(int id);
        CategoryVM GetCategoryVMById(int id);
    }
}