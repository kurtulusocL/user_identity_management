using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Business.Abstract;

namespace UserManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        public ActionResult _Navbar()
        {
            return View();
        }
        public ActionResult _NavbarUser(string userId)
        {
            userId = Convert.ToString(Session["userId"]);
            return PartialView(_userService.GetUserByIdSync(userId));
        }
    }
}