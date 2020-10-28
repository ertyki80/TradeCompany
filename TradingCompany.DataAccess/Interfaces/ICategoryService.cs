using System.Collections.Generic;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface ICategoryService
    {
        CategoryDTO GetCategory(int id);
        List<CategoryDTO> GetAllCategory();
       
    }
}
