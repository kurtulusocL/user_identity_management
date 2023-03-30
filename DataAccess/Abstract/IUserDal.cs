using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DataAccess;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

namespace UserManagement.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<ApplicationUser>
    {
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserById(string id);
        ApplicationUser GetUserByIdSync(string id);
    }
}
