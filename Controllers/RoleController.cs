using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagement.Business.Abstract;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto;

namespace UserManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUserRoleService _roleService;
        public RoleController(IUserRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _roleService.GetAll());
        }
        public async Task<ActionResult> Detail(string id)
        {
            return View(await _roleService.GetById(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationRole roleName)
        {
            var result = await _roleService.Create(roleName);
            if (result == true)
            {
                TempData["success"] = "Created";
                return RedirectToAction(nameof(Create));
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Create));
        }
        public async Task<ActionResult> Edit(string id)
        {
            var updateRole = await _roleService.GetById(id);
            if (updateRole != null)
            {
                return View(updateRole);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationRole roleName)
        {
            var result = await _roleService.Update(roleName);
            if (result == true)
            {
                TempData["success"] = "Updated";
                return RedirectToAction(nameof(Edit), new { id = roleName.Id });
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Edit), new { id = roleName.Id });
        }
        public async Task<ActionResult> Delete(string id)
        {
            var deleteRole = await _roleService.GetById(id);
            if (deleteRole != null)
            {
                await _roleService.Delete(deleteRole);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}