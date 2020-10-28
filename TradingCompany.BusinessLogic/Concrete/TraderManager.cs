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
    class TraderManager : ITraderManager
    {
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;
        public TraderManager(IProductService productService, ITransactionService transaction)
        {
            _productService = productService;
            _transactionService = transaction;

        }

        public TransactionDTO AddTansaction(TransactionDTO transaction)
        {
            return _transactionService.Create(transaction);
        }

        public void BuyManyProducts(ProductDTO product, int count)
        {
            throw new NotImplementedException();
        }

        public void BuyProduct(ProductDTO product)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public TransactionDTO UpdateTransaction(int id,TransactionDTO transaction)
        {
            return _transactionService.Update(id, transaction);
        }
    }
}
