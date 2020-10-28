using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.BusinessLogic.Concrete
{
    public class TraderManager : ITraderManager
    {
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        private readonly IStatusService _statusService;
        public TraderManager(IProductService productService, ITransactionService transactionService, IUserService userService, IStatusService statusService)
        {
            _productService = productService;
            _transactionService = transactionService;
            _userService = userService;
            _statusService = statusService;
        }

        public TransactionDTO AddTansaction(TransactionDTO transaction)
        {
            return _transactionService.Create(transaction);
        }

        public void BuyManyProducts(ProductDTO product, int count)
        {
            product.CountInStock = product.CountInStock - count;
            _productService.Update(product);
        }

        public void BuyProduct(ProductDTO product)
        {
            product.CountInStock--;
            _productService.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productService.Delete(id);
        }

        public void DeleteTransaction(int transactionID)
        {
            _transactionService.Delete(transactionID);
        }

        public List<ProductDTO> GetAllProduct()
        {
            return _productService.GetAllProducts();
        }

        public List<TransactionDTO> GetAllTransaction()
        {
            return _transactionService.GetAllTransactions();
        }

        public StatusDTO GetStatusTransaction(int id)
        {
           return  _statusService.GetStatus(id);
        }

        public UserDTO GetUserById(int id)
        {
            return _userService.GetUser(id);
        }

        public TransactionDTO UpdateTransaction(int id,TransactionDTO transaction)
        {
            return _transactionService.Update(id, transaction);
        }
    }
}
