using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    interface IProductService
    {
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO Create(ProductDTO product);
        void Update(int id, ProductDTO product);
        void Delete(int id);

    }
}
