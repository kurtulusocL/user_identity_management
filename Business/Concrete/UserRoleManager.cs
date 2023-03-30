using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Business.Abstract;
using UserManagement.DataAccess.Abstract;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto;

namespace UserManagement.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public async Task<bool> Create(ApplicationRole roleName)
        {
            await _userRoleDal.Create(roleName);
            return true;
        }

        public async Task<bool> Delete(ApplicationRole model)
        {
            await _userRoleDal.DeleteAsync(model);
            return true;
        }

        public async Task<List<ApplicationRole>> GetAll()
        {
            return await _userRoleDal.GetAllRoles();
        }

        public async Task<ApplicationRole> GetById(string id)
        {
            return await _userRoleDal.GetRoleById(id);
        }

        public async Task<bool> Update(ApplicationRole roleName)
        {
            await _userRoleDal.UpdateAsync(roleName);
            return true;
        }
    }
}