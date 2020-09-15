using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Interfaces
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
