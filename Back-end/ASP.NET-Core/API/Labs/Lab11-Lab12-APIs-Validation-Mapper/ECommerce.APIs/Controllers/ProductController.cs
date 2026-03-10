using ECommerce.BLL;
using ECommerce.DAL;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAllProducts()
        {
            var products = _productManager.GetAllProducts();
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productManager.GetProduct(id);

            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _productManager.AddProduct(productCreateVM);

            return CreatedAtAction(nameof(GetProductById), new { id = productCreateVM.Id }, productCreateVM);

        }

        [HttpPut("{id:int}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] ProductEditVM productEdit)
        {
            var product = _productManager.GetProduct(id);

            if (product == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var productUpdated = _productManager.EditProduct(id, productEdit);

            if (product == null)
                return NotFound();

            return Ok(productUpdated);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productManager.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("category/{categoryId:int}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = _productManager.GetProductsByCategoryId(categoryId);
            return Ok(products);
        }
    }
}
