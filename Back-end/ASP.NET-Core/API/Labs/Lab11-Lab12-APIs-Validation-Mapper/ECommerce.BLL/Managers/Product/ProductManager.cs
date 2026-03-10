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

        public void AddProduct(ProductCreateVM productCreateVM)
        {
            Product product = new Product
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                ExpiryDate = productCreateVM.ExpiryDate,
                CategoryId = productCreateVM.CategoryId,
            };
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
        }

        public Product? EditProduct(int id, ProductEditVM productEditVM)
        {
            if(id != productEditVM.Id)
            {
                return null;
            }

            var productUpdated = _unitOfWork.ProductRepository.GetById(id);

            if (productUpdated == null)
                return null;

            productUpdated.Name = productEditVM.Name;
            productUpdated.Description = productEditVM.Description;
            productUpdated.Price = productEditVM.Price;
            productUpdated.Count = productEditVM.Count;
            productUpdated.ExpiryDate = (DateOnly?)productEditVM.ExpiryDate;
            productUpdated.CategoryId = productEditVM.CategoryId;

            _unitOfWork.Save();

            return productUpdated;
        }

        public void DeleteProduct(int id)
        {
            var productDeleted = _unitOfWork.ProductRepository.GetById(id);
            if (productDeleted == null)
                return;

            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<ProductReadVM> GetProductsByCategoryId(int categoryId)
        {
            var products = _unitOfWork.ProductRepository.GetAllByCategoryId(categoryId)
                .Select(product => new ProductReadVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Count = product.Count,
                    ExpiryDate = product.ExpiryDate ?? new DateOnly(1, 1, 1),
                    ImagePath = product.Image,
                    CategoryId = product.CategoryId,
                    //CategoryName = product.Category.Name,
                });
            return products;
        }
    }
}
