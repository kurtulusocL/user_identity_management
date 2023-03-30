using System.Web.Mvc;
using System.Threading.Tasks;
using UserManagement.Entities.Dtos.AuthDtos;
using UserManagement.Business.Abstract;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

namespace UserManagement.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginDto model)
        {
            ApplicationUser user = new ApplicationUser();

            Session["userNameSurname"] = user.NameSurname;
            Session["username"] = user.UserName;
            Session["userId"] = user.Id;

            var result = await _authService.Login(model);
            if (result == true)
            {
                return RedirectToAction("Index", "Admin", new { id = user.Id });
            }
            TempData["error"] = "There is not a admin with this username and password. Please check to your username and password.";
            return RedirectToAction(nameof(Login));
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterDto model)
        {
            var result = await _authService.Register(model);
            if (result == true)
            {
                TempData["success"] = "Registered";
                return RedirectToAction(nameof(Register));
            }
            TempData["error"] = "MISTAKE!";
            return RedirectToAction(nameof(Register));
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            var result = await _authService.ForgotPassword(model);
            if (result == true)
            {
                return RedirectToAction(nameof(ResetPassword));
            }
            TempData["error"] = "MISTAKE!";
            return RedirectToAction(nameof(ForgotPassword));
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto model)
        {
            var result = await _authService.ResetPassword(model);
            if (result == true)
            {
                return RedirectToAction(nameof(Login));
            }
            TempData["error"] = "MISTAKE!";
            return RedirectToAction(nameof(ResetPassword));
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public async Task<ActionResult> UpdateProfile()
        {
            UpdateProfileDto model = new UpdateProfileDto();
            var result = await _authService.UpdateProfileGet(model);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProfile(UpdateProfileDto model)
        {
            var result = await _authService.UpdateProfilePost(model);
            if (result == true)
            {
                TempData["success"] = "Profile Updated.";
                return RedirectToAction(nameof(UpdateProfile));
            }
            TempData["error"] = "MISTAKE!";
            return RedirectToAction(nameof(UpdateProfile));
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordDto model)
        {
            var result = await _authService.ChangePassword(model);
            if (result == true)
            {
                TempData["success"] = "Password Changed.";
                return RedirectToAction(nameof(ChangePassword));
            }
            TempData["error"] = "MISTAKE!";
            return RedirectToAction(nameof(ChangePassword));
        }

        public ActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}