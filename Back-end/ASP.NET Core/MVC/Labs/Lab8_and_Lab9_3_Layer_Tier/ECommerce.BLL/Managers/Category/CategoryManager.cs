using ECommerce.DAL;

namespace ECommerce.BLL
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CategoryVM> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAllByProducts()
                                          .Select(c => new CategoryVM
                                          {
                                              Id = c.Id,
                                              Name = c.Name,
                                              ProductCounts = c.Products.Count(),
                                              products = c.Products
                                          });
            return categories;
        }

        public CategoryVM? GetCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetByIdWithProducts(id);

            if (category == null)
                return null;

            var categoryVM = new CategoryVM
            {
                Name = category.Name,
                Id = category.Id,
                ProductCounts = category.Products.Count(),
                products = category.Products
            };
            return categoryVM;
        }

        public void AddCategory(CategoryVM categoryVM)
        {
            var category = new Category { Name = categoryVM.Name };
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Save();
        }

        public CategoryVM GetCategoryVMById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            var categoryVM = new CategoryVM
            {
                Name = category.Name,
                Id = category.Id,
            };
            return categoryVM;
        }

        public void EditCategory(CategoryVM categoryVM)
        {
            var categoryUpdated = _unitOfWork.CategoryRepository.GetById(categoryVM.Id);
            if (categoryUpdated == null)
                return;

            categoryUpdated.Name = categoryVM.Name;
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetByIdWithProducts(id);
            if (category == null)
                return;

            category.IsDeleted = true;
            foreach (var product in category.Products)
            {
                product.IsDeleted = true;
            }

            _unitOfWork.Save();
        }
    }
}
