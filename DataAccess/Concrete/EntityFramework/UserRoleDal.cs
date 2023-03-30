using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Core.DataAccess.EntityFramework;
using UserManagement.DataAccess.Abstract;
using UserManagement.DataAccess.Concrete.EntityFramework.Context;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto;
using UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto;
using UserManagement.Core.Entities;

namespace UserManagement.DataAccess.Concrete.EntityFramework
{
    public class UserRoleDal : EntityRepositoryBase<ApplicationRole, ApplicationDbContext>, IUserRoleDal
    {
        private RoleManager<ApplicationRole> roleManager;
        public UserRoleDal()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);

        }
        public async Task<bool> Create(ApplicationRole roleName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                IdentityResult result = await roleManager.CreateAsync(roleName);
                return true;
            }
        }

        public async Task<List<ApplicationRole>> GetAllRoles()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<ApplicationRole>().Include("Users").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<ApplicationRole> GetRoleById(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<ApplicationRole>().Include("Users").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}