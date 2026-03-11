using ECommerce.Common;
using ECommerce.DAL;
using FluentValidation;

namespace ECommerce.BLL
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ProductWriteDto> _writeProductValidator;
        public ProductManager(IUnitOfWork unitOfWork, IValidator<ProductWriteDto> writeProductValidator)
        {
            _unitOfWork = unitOfWork;
            _writeProductValidator = writeProductValidator;
        }

        public async Task<GeneralResult<IEnumerable<ProductReadDto>>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllWithCategoryAsync();

            //Mapping to DTO
            var productsReadDto = products.Select(p => p.ToReadDTO());

            return GeneralResult<IEnumerable<ProductReadDto>>.SuccessedResult(productsReadDto);
        }

        public async Task<GeneralResult<ProductReadDto?>> GetProductAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdWithCategoryAsync(id);

            if (product == null)
                return GeneralResult<ProductReadDto?>.NotFound("This Product Not Found");

            //Mapping to DTO
            var productReadDto = product.ToReadDTO();

            return GeneralResult<ProductReadDto?>.SuccessedResult(productReadDto);
        }

        public async Task<GeneralResult<ProductReadDto?>> AddProductAsync(ProductWriteDto productWriteDto)
        {
            var validationResult = await _writeProductValidator.ValidateAsync(productWriteDto);
            if (!validationResult.IsValid)
            {
                Dictionary<string, List<Error>> errors = validationResult.ToError();
                return GeneralResult<ProductReadDto?>.FailedResult(errors);
            }

            //Mapping from DTO to Model
            Product product = productWriteDto.ToProductModel();

            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();

            //Mapping to DTO
            var productHelper = await _unitOfWork.ProductRepository.GetByIdWithCategoryAsync(product.Id);
            ProductReadDto productReadDto = productHelper!.ToReadDTO();

            return GeneralResult<ProductReadDto?>.SuccessedResult(productReadDto);
        }

        public async Task<GeneralResult<ProductReadDto?>> EditProductAsync(int id, ProductWriteDto productWriteDto)
        {
            var validationResult = await _writeProductValidator.ValidateAsync(productWriteDto);
            if (!validationResult.IsValid)
            {
                Dictionary<string, List<Error>> errors = validationResult.ToError();
                return GeneralResult<ProductReadDto?>.FailedResult(errors);
            }

            var productUpdated = await _unitOfWork.ProductRepository.GetByIdWithCategoryAsync(id);
            if (productUpdated == null)
            {
                return GeneralResult<ProductReadDto?>.NotFound("This Product Not Found");
            }

            productUpdated.Name = productWriteDto.Name;
            productUpdated.Description = productWriteDto.Description;
            productUpdated.Price = productWriteDto.Price;
            productUpdated.Count = productWriteDto.Count;
            productUpdated.ExpiryDate = (DateOnly?)productWriteDto.ExpiryDate;
            productUpdated.CategoryId = productWriteDto.CategoryId;

            _unitOfWork.Save();

            //Mapping to DTO
            var product = await _unitOfWork.ProductRepository.GetByIdWithCategoryAsync(productUpdated.Id);
            ProductReadDto productReadDto = product!.ToReadDTO();

            return GeneralResult<ProductReadDto?>.SuccessedResult(productReadDto);
        }

        public async Task<GeneralResult> DeleteProductAsync(int id)
        {
            var productDeleted = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (productDeleted == null)
                return GeneralResult.NotFound("This Product Not Found");

            await _unitOfWork.ProductRepository.DeleteAsync(id);
            _unitOfWork.Save();

            return GeneralResult.SuccessedResult();
        }

        public async Task<GeneralResult<IEnumerable<ProductReadDto>>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var isCategoryExist = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
            if (isCategoryExist == null)
            {
                return GeneralResult<IEnumerable<ProductReadDto>>.NotFound("This Category Not Found");
            }

            var products = await _unitOfWork.ProductRepository.GetAllByCategoryIdAsync(categoryId);

            //Mapping to DTO
            var productsReadDto = products.Select(p => p.ToReadDTO());

            return GeneralResult<IEnumerable<ProductReadDto>>.SuccessedResult(productsReadDto);
        }
    }
}