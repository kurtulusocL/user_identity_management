using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Core.DataAccess.EntityFramework;
using UserManagement.DataAccess.Abstract;
using UserManagement.DataAccess.Concrete.EntityFramework.Context;
using UserManagement.Entities.Concrete;

namespace UserManagement.DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDal
    {
        public async Task<List<Category>> GetAllCategories()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Category>().Include("Products").OrderByDescending(i => i.Products.Count()).ToListAsync();
            }
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Category>().Include("Products").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}