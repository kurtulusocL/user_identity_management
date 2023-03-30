using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities.Concrete;

namespace UserManagement.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int? id);
        Task<bool> Create(Category model);
        Task<bool> Update(Category model);
        Task<bool> Delete(Category model);
    }
}
