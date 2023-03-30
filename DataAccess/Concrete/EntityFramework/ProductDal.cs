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
    public class ProductDal : EntityRepositoryBase<Product, ApplicationDbContext>, IProductDal
    {
        public async Task<List<Product>> GetAllProducts()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Product>().Include("Category").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<List<Product>> GetAllProductsByCategoryId(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Product>().Include("Category").Where(i => i.CategoryId == id).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<Product> GetById(int? id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Set<Product>().Include("Category").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }
    }
}