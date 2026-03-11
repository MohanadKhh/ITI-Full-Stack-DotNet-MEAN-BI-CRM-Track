using ECommerce.Common;

namespace ECommerce.BLL
{
    public interface IProductManager
    {
        Task<GeneralResult<ProductReadDto?>> AddProductAsync(ProductWriteDto productWriteDto);
        Task<GeneralResult> DeleteProductAsync(int id);
        Task<GeneralResult<ProductReadDto?>> EditProductAsync(int id, ProductWriteDto productWriteDto);
        Task<GeneralResult<IEnumerable<ProductReadDto>>> GetAllProductsAsync();
        Task<GeneralResult<ProductReadDto?>> GetProductAsync(int id);
        Task<GeneralResult<IEnumerable<ProductReadDto>>> GetProductsByCategoryIdAsync(int categoryId);
    }
}