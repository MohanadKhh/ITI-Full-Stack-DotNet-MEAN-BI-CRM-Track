using ECommerce.DAL;

namespace ECommerce.BLL
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductReadVM> GetAllProducts()
        {
            var productsVM = _unitOfWork.ProductRepository.GetAllWithCategory()
                .Select(p => new ProductReadVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Count = p.Count,
                    ImagePath = p.Image,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                });
            return productsVM;
        }

        public ProductReadVM? GetProduct(int id)
        {
            var product = _unitOfWork.ProductRepository.GetByIdWithCategory(id);

            if (product == null)
                return null;

            var productVM = new ProductReadVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                ExpiryDate = product.ExpiryDate ?? new DateOnly(1, 1, 1),
                ImagePath = product.Image,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
            };
            return productVM;
        }

        public IEnumerable<CategoryVM> GetCategoriesList()
        {
            var categoriesList = _unitOfWork.CategoryRepository.GetAll()
                            .Select(c => new CategoryVM
                            {
                                Id = c.Id,
                                Name = c.Name,
                            });
            return categoriesList;
        }

        public ProductCreateVM GetProductCreateView()
        {
            return new ProductCreateVM
            {
                ExpiryDate = DateOnly.FromDateTime(DateTime.Today.AddYears(2)),
                Categories = GetCategoriesList()
            };
        }

        public void AddProduct(ProductCreateVM productCreateVM, string ImagePath)
        {
            Product product = new Product
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                ExpiryDate = productCreateVM.ExpiryDate,
                Image = ImagePath,
                CategoryId = productCreateVM.CategoryId,
            };
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
        }

        public ProductEditVM? GetProductEditVMById(int id)
        {
            var product = _unitOfWork.ProductRepository.GetByIdWithCategory(id);
            if (product == null)
                return null;

            var productEditVM = new ProductEditVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                ExpiryDate = product.ExpiryDate ?? new DateOnly(1, 1, 1),
                ImagePath = product.Image,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Categories = GetCategoriesList()
            };

            return productEditVM;
        }

        public void EditProduct(ProductEditVM productEditVM, string? ImagePath)
        {
            var productUpdated = _unitOfWork.ProductRepository.GetById(productEditVM.Id);

            if (productUpdated == null)
                return;

            productUpdated.Name = productEditVM.Name;
            productUpdated.Description = productEditVM.Description;
            productUpdated.Price = productEditVM.Price;
            productUpdated.Count = productEditVM.Count;
            productUpdated.ExpiryDate = (DateOnly?)productEditVM.ExpiryDate;
            productUpdated.CategoryId = productEditVM.CategoryId;

            if (ImagePath != null)
                productUpdated.Image = ImagePath;

            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var productDeleted = _unitOfWork.ProductRepository.GetById(id);
            if (productDeleted == null)
                return;

            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<ProductIdName> GetProductsListOfCategory(int categoryId)
        {
            var products = _unitOfWork.ProductRepository.GetAllByCategoryId(categoryId)
                .Select(p => new ProductIdName
                {
                    Id = p.Id,
                    Name = p.Name,
                });
            return products;
        }

        public ProductsDropdownVM GetProductDropDownVM(int categoryId)
        {
            var products = new ProductsDropdownVM
            {
                Products = GetProductsListOfCategory(categoryId),
            };
            return products;
        }
    }
}
