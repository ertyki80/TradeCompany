using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface ITransactionService
    {
        TransactionDTO GetTransaction(int id);
        List<TransactionDTO> GetAllTransactions();
        TransactionDTO Create(TransactionDTO transaction);
        TransactionDTO Update(int id, TransactionDTO transaction);
        void Delete(int id);
    }
}
