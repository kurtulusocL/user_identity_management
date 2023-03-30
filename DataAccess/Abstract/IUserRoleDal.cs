using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DataAccess;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto;

namespace UserManagement.DataAccess.Abstract
{
    public interface IUserRoleDal : IEntityRepository<ApplicationRole>
    {
        Task<List<ApplicationRole>> GetAllRoles();
        Task<ApplicationRole> GetRoleById(string id);
        Task<bool> Create(ApplicationRole roleName);
    }
}
