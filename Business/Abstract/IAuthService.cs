using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities.Dtos.AuthDtos;

namespace UserManagement.Business.Abstract
{
    public interface IAuthService
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
