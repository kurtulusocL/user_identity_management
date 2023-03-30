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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<bool> Create(Category model)
        {
            await _categoryDal.AddAsync(model);
            return true;
        }

        public async Task<bool> Delete(Category model)
        {
            await _categoryDal.DeleteAsync(model);
            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryDal.GetAllCategories();
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryDal.GetCategoryById(id);
        }

        public async Task<bool> Update(Category model)
        {
            await _categoryDal.UpdateAsync(model);
            return true;
        }
    }
}