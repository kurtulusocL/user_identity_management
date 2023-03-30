using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Business.Abstract;
using UserManagement.DataAccess.Abstract;
using UserManagement.Entities.Concrete;

namespace UserManagement.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<bool> Create(Product entity)
        {
            await _productDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            await _productDal.DeleteAsync(entity);
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productDal.GetAllProducts();
        }

        public async Task<List<Product>> GetAllProductsByCategoryId(int? id)
        {
            return await _productDal.GetAllProductsByCategoryId(id);
        }

        public async Task<Product> GetById(int? id)
        {
            return await _productDal.GetById(id);
        }

        public async Task<bool> Update(Product entity)
        {
            await _productDal.UpdateAsync(entity);
            return true;
        }
    }
}