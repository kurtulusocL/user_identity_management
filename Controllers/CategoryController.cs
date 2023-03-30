using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagement.Business.Abstract;
using UserManagement.Entities.Concrete;

namespace UserManagement.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _categoryService.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category model)
        {
            var result = await _categoryService.Create(model);
            if (result == true)
            {
                TempData["success"] = "Created";
                return RedirectToAction(nameof(Create));
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Create));
        }
        public async Task<ActionResult> Edit(int? id)
        {
            var updateCategory = await _categoryService.GetById(id);
            if (updateCategory != null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category model)
        {
            var result = await _categoryService.Update(model);
            if (result == true)
            {
                TempData["success"] = "Updated";
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
        public async Task<ActionResult> Delete(int? id)
        {
            var deleteCategory = await _categoryService.GetById(id);
            if (deleteCategory != null)
            {
                await _categoryService.Delete(deleteCategory);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}