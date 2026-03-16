using ECommerce.BLL;
using ECommerce.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productManager.GetAllProductsAsync();

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("Pagination")]
        public async Task<IActionResult> GetAllProductsByPagination
            ([FromQuery] PaginationParameters paginationParameters,
            [FromQuery] ProductFilter productFilter)
        {
            var result = await _productManager.GetAllProductsByPaginationAsync(paginationParameters, productFilter);

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await _productManager.GetProductAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductWriteDto productWriteDto)
        {
            var result = await _productManager.AddProductAsync(productWriteDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditAsync([FromRoute] int id, [FromBody] ProductWriteDto productWriteDto)
        {
            var updatedResult = await _productManager.EditProductAsync(id, productWriteDto);

            if (!updatedResult.Success)
            {
                if (updatedResult.Errors != null)
                {
                    return BadRequest(updatedResult);
                }
                else
                {
                    return NotFound(updatedResult);
                }
            }

            return Ok(updatedResult);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productManager.DeleteProductAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetProductsByCategoryIdAsync(int categoryId)
        {
            var result = await _productManager.GetProductsByCategoryIdAsync(categoryId);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}