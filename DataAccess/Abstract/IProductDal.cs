using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DataAccess;
using UserManagement.Entities.Concrete;

namespace UserManagement.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProductsByCategoryId(int? id);
        Task<Product> GetById(int? id);
    }
}
