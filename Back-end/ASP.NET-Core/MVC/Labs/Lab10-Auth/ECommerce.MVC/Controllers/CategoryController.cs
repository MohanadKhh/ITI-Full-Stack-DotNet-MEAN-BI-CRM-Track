using ECommerce.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            var categoriesVM = _categoryManager.GetAllCategories();
            return View(categoriesVM);
        }

        // GET: CategoryController/Details/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int id)
        {
            var categoryVM = _categoryManager.GetCategory(id);
            if (categoryVM == null)
                return RedirectToAction(nameof(Index));
            return View(categoryVM);
        }

        // GET: CategoryController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVM);
            }
            _categoryManager.AddCategory(categoryVM);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var categoryVM = _categoryManager.GetCategoryVMById(id);
            if (categoryVM == null)
                return RedirectToAction(nameof(Index));
            return View(categoryVM);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CategoryVM category)
        {
            _categoryManager.EditCategory(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _categoryManager.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
