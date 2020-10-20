using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    interface ITransactionService
    {
        TransactionDTO GetTransaction(int id);
        IEnumerable<TransactionDTO> GetAllTransactions();
        TransactionDTO Create(TransactionDTO transaction);
        void Update(int id, TransactionDTO transaction);
        void Delete(int id);
    }
}
