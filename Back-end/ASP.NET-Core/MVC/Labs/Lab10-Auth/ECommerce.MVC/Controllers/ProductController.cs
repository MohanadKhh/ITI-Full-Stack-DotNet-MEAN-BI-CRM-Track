using ECommerce.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        // GET: ProductController
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {
            var products = _productManager.GetAllProducts();
            return View(products);
        }

        // GET: ProductController/Details/5
        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var product = _productManager.GetProduct(id);

            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }

        // GET: ProductController/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var productCreateVM = _productManager.GetProductCreateView();
            return View(productCreateVM);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductCreateVM productCreateVM, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                productCreateVM.Categories = _productManager.GetCategoriesList();
                return View(productCreateVM);
            }

            _productManager.AddProduct(productCreateVM, SaveImage(imageFile));

            return RedirectToAction(nameof(Index));

        }

        // GET: ProductController/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var productEditVM = _productManager.GetProductEditVMById(id);
            if (productEditVM == null)
                return RedirectToAction(nameof(Index));

            return View(productEditVM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ProductEditVM productEditVM, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                productEditVM.Categories = _productManager.GetCategoriesList();
                return View(productEditVM);
            }

            string? uniqueFileName = null;

            if (imageFile != null)
            {
                uniqueFileName = SaveImage(imageFile);
            }

            _productManager.EditProduct(productEditVM, uniqueFileName);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _productManager.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult SearchOnProductsByCategory()
        {
            var categorySearch = new CategorySearchVM
            {
                Categories = _productManager.GetCategoriesList()
            };
            return View(categorySearch);
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var productsDropDown = _productManager.GetProductDropDownVM(categoryId);
            return PartialView("_ProductsDropdownPartial", productsDropDown);
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult GetProductFromDropDown(int id)
        {
            var product = _productManager.GetProduct(id);

            if (product == null)
                return RedirectToAction(nameof(SearchOnProductsByCategory));

            return PartialView("_ProductPartial", product);
        }

        string SaveImage(IFormFile imageFile)
        {
            //defint image file name with same extension
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            //define folder path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Products");

            //creating folder if not exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //adding image in folder
            using (var stream = new FileStream(Path.Combine(folderPath, uniqueFileName), FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return uniqueFileName;
        }
    }
}
