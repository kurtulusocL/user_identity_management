using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.DataAccess;
using UserManagement.Entities.Concrete;

namespace UserManagement.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int? id);
    }
}
