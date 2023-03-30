using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DataAccess;
using UserManagement.Entities.Dtos.AuthDtos;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

namespace UserManagement.DataAccess.Abstract
{
    public interface IAuthDal:IEntityRepository<ApplicationUser>
    {
        Task<bool> Login(LoginDto model);
        Task<bool> Register(RegisterDto model);
        Task<bool> UpdateProfilePost(UpdateProfileDto model);
        Task<bool> UpdateProfileGet(UpdateProfileDto model);
        Task<bool> ChangePassword(ChangePasswordDto model);
        Task<bool> ResetPassword(ResetPasswordDto model);
        Task<bool> ForgotPassword(ForgotPasswordDto model);
        void Logout();
    }
}
