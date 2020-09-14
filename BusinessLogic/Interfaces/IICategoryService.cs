using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IICategoryService
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategory();
        void Create(Category category);
        void Update(int id, Category category);
        void Delete(int id);

    }
}
