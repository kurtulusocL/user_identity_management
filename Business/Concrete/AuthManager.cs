using System.Threading.Tasks;
using UserManagement.Business.Abstract;
using UserManagement.DataAccess.Abstract;
using UserManagement.Entities.Dtos.AuthDtos;

namespace UserManagement.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IAuthDal _authDal;
        public AuthManager(IAuthDal authDal)
        {
            _authDal = authDal;
        }

        public async Task<bool> ChangePassword(ChangePasswordDto model)
        {
            var result = await _authDal.ChangePassword(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordDto model)
        {
            var result = await _authDal.ForgotPassword(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Login(LoginDto model)
        {
            var result = await _authDal.Login(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _authDal.Logout();
        }

        public async Task<bool> Register(RegisterDto model)
        {
            var result = await _authDal.Register(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto model)
        {
            var result = await _authDal.ResetPassword(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProfileGet(UpdateProfileDto model)
        {
            var result = await _authDal.UpdateProfileGet(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProfilePost(UpdateProfileDto model)
        {
            var result = await _authDal.UpdateProfilePost(model);
            if (result == true)
            {
                return true;
            }
            return false;
        }
    }
}