using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities.Concrete;

namespace UserManagement.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAllProductsByCategoryId(int? id);
        Task<Product> GetById(int? id);
        Task<bool> Create(Product entity);
        Task<bool> Update(Product entity);
        Task<bool> Delete(Product entity);
    }
}
