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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _productService.GetAll());
        }
        public async Task<ActionResult> Category(int? id)
        {
            return View(await _productService.GetAllProductsByCategoryId(id));
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product model)
        {
            var result = await _productService.Create(model);
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
            ViewBag.Categories = await _categoryService.GetAll();
            var updateProduct = await _productService.GetById(id);
            if (updateProduct != null)
            {
                return View(updateProduct);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product model)
        {
            var result = await _productService.Update(model);
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
            var deleteProduct = await _productService.GetById(id);
            if (deleteProduct != null)
            {
                await _productService.Delete(deleteProduct);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}