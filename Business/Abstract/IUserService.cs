using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

namespace UserManagement.Business.Abstract
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAll();
        Task<List<ApplicationUser>> GetAllUsersByRoleId(string id);
        Task<ApplicationUser> GetById(string id);
        ApplicationUser GetUserByIdSync(string id);
        Task<bool> Delete(ApplicationUser entity);
    }
}
