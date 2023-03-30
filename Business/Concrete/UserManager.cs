using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Business.Abstract;
using UserManagement.DataAccess.Abstract;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

namespace UserManagement.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<bool> Delete(ApplicationUser entity)
        {
           await _userDal.DeleteAsync(entity);
            return true;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _userDal.GetAllUsers();
        }

        public async Task<List<ApplicationUser>> GetAllUsersByRoleId(string id)
        {          
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _userDal.GetUserById(id);
        }

        public ApplicationUser GetUserByIdSync(string id)
        {
            return _userDal.GetUserByIdSync(id);
        }
    }
}