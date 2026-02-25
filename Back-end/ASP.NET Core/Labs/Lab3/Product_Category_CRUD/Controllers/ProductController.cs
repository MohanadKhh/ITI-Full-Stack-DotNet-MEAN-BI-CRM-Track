using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_Category_CRUD.Data.Context;
using Product_Category_CRUD.Models;
using Product_Category_CRUD.ViewModels;

namespace Product_Category_CRUD.Controllers
{
    public class ProductController : Controller
    {
        AppDBContext Db = new AppDBContext();

        // GET: ProductController
        public ActionResult Index()
        {
            var products = Db.Products.Include(p => p.Category).Select(p => new ProductReadVM
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Count = p.Count,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
            });
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = Db.Products.Include(p => p.Category).Where(p => p.Id == id)
                                    .Select(p => new ProductReadVM
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Description = p.Description,
                                        Price = p.Price,
                                        Count = p.Count,
                                        CategoryId = p.CategoryId,
                                        CategoryName = p.Category.Name,
                                    })
                                    .SingleOrDefault();

            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var productCreateVM = new ProductCreateVM
            {
                Categories = GetDropDownItemsOfCatrgories()
            };
            return View(productCreateVM);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateVM productCreateVM)
        {
            Product product = new Product
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                CategoryId = productCreateVM.CategoryId,
            };

            Db.Products.Add(product);
            Db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = Db.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
            if (product == null)
                return RedirectToAction(nameof(Index));

            var productCreateVM = new ProductCreateVM
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Categories = GetDropDownItemsOfCatrgories()
            };
            return View(productCreateVM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCreateVM productCreateVM)
        {
            var productUpdated = Db.Products.SingleOrDefault(p => p.Id == productCreateVM.Id);

            if (productUpdated == null)
                return RedirectToAction(nameof(Index));

            productUpdated.Name = productCreateVM.Name;
            productUpdated.Description = productCreateVM.Description;
            productUpdated.Price = productCreateVM.Price;
            productUpdated.Count = productCreateVM.Count;
            productUpdated.CategoryId = productCreateVM.CategoryId;
            Db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = Db.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return RedirectToAction(nameof(Index));

            Db.Products.Remove(product);
            Db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        List<SelectListItem> GetDropDownItemsOfCatrgories()
        {
            return Db.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
        }
    }
}
