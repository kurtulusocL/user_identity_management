using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserManagement.Core.DataAccess.EntityFramework;
using UserManagement.DataAccess.Abstract;
using UserManagement.DataAccess.Concrete.EntityFramework.Context;
using UserManagement.Entities.Dtos.AuthDtos;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace UserManagement.DataAccess.Concrete.EntityFramework
{
    public class AuthDal : EntityRepositoryBase<ApplicationUser, ApplicationDbContext>, IAuthDal
    {
        private UserManager<ApplicationUser> userManager;
        private readonly UrlHelper urlHelper;
        ApplicationDbContext context;
        public AuthDal()
        {
            urlHelper = new UrlHelper();
            context = new ApplicationDbContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(context);
        }
        public async Task<bool> ChangePassword(ChangePasswordDto model)
        {
            IdentityUser user = await userManager.FindByNameAsync(HttpContext.Current.User.Identity.Name);
            IdentityResult result = await userManager.ChangePasswordAsync(user.Id, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ForgotPassword(ForgotPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await userManager.IsEmailConfirmedAsync(user.Id)))
            {
                return false;
            }
            var provider = new DpapiDataProtectionProvider("UserManagement");
            userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

            var code = await userManager.GeneratePasswordResetTokenAsync(user.Id);

            var callbackUrl = urlHelper.Action("ResetPassword", "Account",
            new { UserId = user.Id, code = code }, protocol: HttpContext.Current.Request.Url.Scheme);

            SmtpClient client = new SmtpClient("smtp.yandex.com.tr", 587);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("your email address", "www.usermanager.com");
            mail.Priority = MailPriority.High;
            mail.Subject = "Forgot to My Password";
            mail.To.Add(new MailAddress(model.Email, ""));
            mail.Body = "Reset Password" + " " + "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>";
            mail.IsBodyHtml = true;

            NetworkCredential enter = new NetworkCredential("your email address", "your password");
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = enter;
            client.Send(mail);

            return true;
        }

        public async Task<bool> Login(LoginDto model)
        {
            ApplicationUser user = await userManager.FindAsync(model.Username, model.Password);
            if (user != null)
            {
                HttpContext.Current.Session["userId"] = user.Id;
                HttpContext.Current.Session["username"] = user.UserName;
                HttpContext.Current.Session["userNameSurname"] = user.NameSurname;
                if (user.IsConfirmed == true)
                {
                    IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
                    ClaimsIdentity identity = await userManager.CreateIdentityAsync(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = true;
                    authManager.SignIn(authProps, identity);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void Logout()
        {
            IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
        }

        public async Task<bool> Register(RegisterDto model)
        {
            ApplicationUser user = new ApplicationUser();

            user.UserName = model.Username;
            user.NameSurname = model.NameSurname;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.CreatedDate = model.CreatedDate.ToLocalTime();

            IdentityResult iResult = await userManager.CreateAsync(user, model.Password);
            if (iResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user.Id, "Admin");
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ResetPassword(ResetPasswordDto model)
        {
            ApplicationUser user = new ApplicationUser();
            user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var provider = new DpapiDataProtectionProvider("UserManagement");
                userManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));
                var result = userManager.ResetPassword(user.Id, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateProfileGet(UpdateProfileDto model)
        {
            ApplicationUser user = await userManager.FindByNameAsync(HttpContext.Current.User.Identity.Name);

            model.Username = user.UserName;
            model.PhoneNumber = user.PhoneNumber;
            model.Email = user.Email;
            model.UpdatedDate = DateTime.Now.ToLocalTime();
            model.IsConfirmed = true;

            return true;
        }

        public async Task<bool> UpdateProfilePost(UpdateProfileDto model)
        {
            ApplicationUser user = await userManager.FindByNameAsync(HttpContext.Current.User.Identity.Name);

            user.UserName = model.Username;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UpdatedDate = model.UpdatedDate;
            user.IsConfirmed = model.IsConfirmed;

            IdentityResult result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}