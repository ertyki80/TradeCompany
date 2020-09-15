using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Models;

namespace BusinessLogic.Interfaces
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
