using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    internal interface ICategoryService
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategory();
        void Create(Category category);
        void Update(int id, Category category);
        void Delete(int id);

    }
}
