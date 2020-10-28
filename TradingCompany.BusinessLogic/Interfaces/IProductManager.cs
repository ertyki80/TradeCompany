using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDataTransfer;

namespace TradingCompany.BusinessLogic.Interfaces
{
    public interface IProductManager
    {

        ProductDTO AddProduct(ProductDTO product);
        List<ProductDTO> GetListOfProducts();
        List<UserDTO> GetListOfPeople();
        List<CategoryDTO> GetListOfCategory();
        ProductDTO UpdateProduct(ProductDTO product);
        void DeleteProduct(int productId);
    }
}
