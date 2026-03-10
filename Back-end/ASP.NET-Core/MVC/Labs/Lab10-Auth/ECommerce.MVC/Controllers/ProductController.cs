using ECommerce.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            var products = _productManager.GetAllProducts();
            return View(products);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var product = _productManager.GetProduct(id);

            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            var productCreateVM = _productManager.GetProductCreateView();
            return View(productCreateVM);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult Delete(int id)
        {
            _productManager.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SearchOnProductsByCategory()
        {
            var categorySearch = new CategorySearchVM
            {
                Categories = _productManager.GetCategoriesList()
            };
            return View(categorySearch);
        }

        public IActionResult GetProductsByCategory(int categoryId)
        {
            var productsDropDown = _productManager.GetProductDropDownVM(categoryId);
            return PartialView("_ProductsDropdownPartial", productsDropDown);
        }

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

        //[AcceptVerbs("GET", "POST")]
        //public IActionResult IsNameUniqueness(string name, int id)
        //{
        //    var isNameExist = Db.Products.Any(p => p.Name == name && p.Id != id);
        //    if (isNameExist)
        //        return Json($"Name {name} is already exists");
        //    return Json(true);
        //}

        //List<SelectListItem> GetDropDownItemsOfCatrgories()
        //{
        //    return Db.Categories.Select(c => new SelectListItem
        //    {
        //        Value = c.Id.ToString(),
        //        Text = c.Name,
        //    }).ToList();
        //}
    }
}
