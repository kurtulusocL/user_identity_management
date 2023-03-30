using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagement.Business.Abstract;

namespace UserManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _userService.GetAll());
        }
        public async Task<ActionResult> Detail(string id)
        {
            return View(await _userService.GetById(id));
        }
        public async Task<ActionResult> Delete(string id)
        {
            var deleteUser = await _userService.GetById(id);
            if (deleteUser != null)
            {
                await _userService.Delete(deleteUser);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}