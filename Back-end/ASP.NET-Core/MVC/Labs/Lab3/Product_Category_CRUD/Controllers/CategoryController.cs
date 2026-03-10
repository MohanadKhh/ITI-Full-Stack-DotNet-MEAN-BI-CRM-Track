using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Category_CRUD.Data.Context;
using Product_Category_CRUD.Models;
using Product_Category_CRUD.ViewModels;

namespace Product_Category_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        AppDBContext db = new AppDBContext();
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.Products).Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                ProductCounts = c.Products.Count(),
            });
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = db.Categories.Include(c => c.Products)
                                        .Where(c => c.Id == id)
                                        .Select(c => new CategoryVM
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            ProductCounts = c.Products.Count(),
                                            products = c.Products
                                        }).SingleOrDefault();
            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM _category)
        {
            var category = new Category { Name = _category.Name };
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = db.Categories.Include(c => c.Products)
                                        .Where(c => c.Id == id)
                                        .Select(c => new CategoryVM
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                        }).SingleOrDefault();
            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryVM category)
        {
            var categoryUpdated = db.Categories.SingleOrDefault(p => p.Id == category.Id);

            if (categoryUpdated == null)
                return RedirectToAction(nameof(Index));

            categoryUpdated.Name = category.Name;
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Include(c => c.Products)
                                        .SingleOrDefault(c => c.Id == id);
            if (category == null)
                return RedirectToAction(nameof(Index));

            category.IsDeleted = true;
            foreach (var product in category.Products)
            {
                product.IsDeleted = true;
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
