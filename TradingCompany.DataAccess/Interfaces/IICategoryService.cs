using System.Collections.Generic;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    internal interface ICategoryService
    {
        CategoryDTO GetCategory(int id);
        IEnumerable<CategoryDTO> GetAllCategory();
       
    }
}
