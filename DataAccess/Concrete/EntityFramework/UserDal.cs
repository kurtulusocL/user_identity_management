using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Core.DataAccess.EntityFramework;
using UserManagement.DataAccess.Abstract;
using UserManagement.DataAccess.Concrete.EntityFramework.Context;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;

namespace UserManagement.DataAccess.Concrete.EntityFramework
{
    public class UserDal : EntityRepositoryBase<ApplicationUser, ApplicationDbContext>, IUserDal
    {
        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<ApplicationUser>().Include("Roles").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<ApplicationUser>().Include("Roles").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public ApplicationUser GetUserByIdSync(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Set<ApplicationUser>().Include("Roles").Where(i => i.Id == id).SingleOrDefault();
            }
        }
    }
}