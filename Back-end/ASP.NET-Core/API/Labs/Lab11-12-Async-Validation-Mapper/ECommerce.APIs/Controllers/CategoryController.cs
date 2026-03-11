using ECommerce.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryManager.GetAllCategoriesAsync();

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryManager.GetCategoryAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryWriteDto categoryWriteDto)
        {
            var result = await _categoryManager.AddCategoryAsync(categoryWriteDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditAsync([FromRoute] int id, [FromBody] CategoryWriteDto categoryWriteDto)
        {
            var updatedResult = await _categoryManager.EditCategoryAsync(id, categoryWriteDto);

            if (!updatedResult.Success)
            {
                if(updatedResult.Errors != null)
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
            var result = await _categoryManager.DeleteCategoryAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
