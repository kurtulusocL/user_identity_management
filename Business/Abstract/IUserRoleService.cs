using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto;

namespace UserManagement.Business.Abstract
{
    public interface IUserRoleService
    {
        Task<List<ApplicationRole>> GetAll();
        Task<ApplicationRole> GetById(string id);
        Task<bool> Create(ApplicationRole roleName);
        Task<bool> Update(ApplicationRole roleName);
        Task<bool> Delete(ApplicationRole model);
    }
}
