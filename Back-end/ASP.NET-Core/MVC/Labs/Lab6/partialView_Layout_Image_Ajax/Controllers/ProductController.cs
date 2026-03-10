using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using partialView_Layout_Image_Ajax.Data.Context;
using partialView_Layout_Image_Ajax.Models;
using partialView_Layout_Image_Ajax.ViewModels;

namespace partialView_Layout_Image_Ajax.Controllers
{
    public class ProductController : Controller
    {
        AppDBContext Db = new AppDBContext();

        // GET: ProductController
        public IActionResult Index()
        {
            var products = Db.Products.Include(p => p.Category).Select(p => new ProductReadVM
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
            return View(products);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var product = Db.Products.Include(p => p.Category).Where(p => p.Id == id)
                                    .Select(p => new ProductReadVM
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Description = p.Description,
                                        Price = p.Price,
                                        Count = p.Count,
                                        ExpiryDate = p.ExpiryDate ?? new DateOnly(1, 1, 1),
                                        ImagePath = p.Image,
                                        CategoryId = p.CategoryId,
                                        CategoryName = p.Category.Name,
                                    })
                                    .SingleOrDefault();

            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            var productCreateVM = new ProductCreateVM
            {
                ExpiryDate = DateOnly.FromDateTime(DateTime.Today.AddYears(2)),
                Categories = GetDropDownItemsOfCatrgories()
            };
            return View(productCreateVM);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid)
            {
                productCreateVM.Categories = GetDropDownItemsOfCatrgories();
                return View(productCreateVM);
            }

            //defint image file name with same extension
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(productCreateVM.ImageFile.FileName);

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
                productCreateVM.ImageFile.CopyTo(stream);
            }

            Product product = new Product
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                ExpiryDate = productCreateVM.ExpiryDate,
                Image = uniqueFileName,
                CategoryId = productCreateVM.CategoryId,
            };

            Db.Products.Add(product);
            Db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            var product = Db.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
            if (product == null)
                return RedirectToAction(nameof(Index));

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
                Categories = GetDropDownItemsOfCatrgories()
            };
            return View(productEditVM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            if (!ModelState.IsValid)
            {
                productEditVM.Categories = GetDropDownItemsOfCatrgories();
                return View(productEditVM);
            }

            var productUpdated = Db.Products.SingleOrDefault(p => p.Id == productEditVM.Id);

            if (productUpdated == null)
                return RedirectToAction(nameof(Index));

            productUpdated.Name = productEditVM.Name;
            productUpdated.Description = productEditVM.Description;
            productUpdated.Price = productEditVM.Price;
            productUpdated.Count = productEditVM.Count;
            productUpdated.ExpiryDate = (DateOnly?)productEditVM.ExpiryDate;
            productUpdated.CategoryId = productEditVM.CategoryId;

            if (productEditVM.ImageFile != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString()
                    + Path.GetExtension(productEditVM.ImageFile.FileName);

                string folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images",
                    "Products");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                using (var stream = new FileStream(
                    Path.Combine(folderPath, uniqueFileName),
                    FileMode.Create))
                {
                    productEditVM.ImageFile.CopyTo(stream);
                }

                productUpdated.Image = uniqueFileName;
            }

            Db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            var product = Db.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return RedirectToAction(nameof(Index));

            Db.Products.Remove(product);
            Db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult IsNameUniqueness(string name, int id)
        {
            var isNameExist = Db.Products.Any(p => p.Name == name && p.Id != id);
            if (isNameExist)
                return Json($"Name {name} is already exists");
            return Json(true);
        }

        public IActionResult SearchOnProductsByCategory()
        {
            var categorySearch = new CategorySearchVM
            {
                Categories = GetDropDownItemsOfCatrgories()
            };
            return View(categorySearch);
        }

        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = new ProductsDropdownVM
            {
                Products = Db.Products.Where(p => p.CategoryId == categoryId)
                                    .Select(p => new SelectListItem
                                    {
                                        Value = p.Id.ToString(),
                                        Text = p.Name,
                                    }).ToList()
            };

            return PartialView("_ProductsDropdownPartial", products);
        }

        public IActionResult GetProduct(int id)
        {
            var product = Db.Products.Include(p => p.Category).Where(p => p.Id == id)
                                    .Select(p => new ProductReadVM
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Description = p.Description,
                                        Price = p.Price,
                                        Count = p.Count,
                                        ExpiryDate = p.ExpiryDate ?? new DateOnly(1, 1, 1),
                                        ImagePath = p.Image,
                                        CategoryId = p.CategoryId,
                                        CategoryName = p.Category.Name,
                                    })
                                    .SingleOrDefault();

            if (product == null)
                return RedirectToAction(nameof(SearchOnProductsByCategory));
            return PartialView("_ProductPartial", product);
        }

        List<SelectListItem> GetDropDownItemsOfCatrgories()
        {
            return Db.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
        }



        //string GetProductImagePath(string imageFileName)
        //{
        //    return Path.Combine("Images", "Products", imageFileName);
        //}
    }
}
