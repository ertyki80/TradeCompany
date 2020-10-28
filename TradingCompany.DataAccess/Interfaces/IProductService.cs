using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(int id);
        List<ProductDTO> GetAllProducts();
        ProductDTO Create(ProductDTO product);
        ProductDTO Update(ProductDTO product);
        void Delete(int id);

    }
}
