using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Interfaces
{
    interface IProductService
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        void Create(Product product);
        void Update(int id, Product product);
        void Delete(int id);

    }
}
