using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Interfaces
{
    interface ITransactionService
    {
        Transaction GetTransaction(int id);
        IEnumerable<Transaction> GetAllTransactions();
        void Create(Transaction transaction);
        void Update(int id, Transaction transaction);
        void Delete(int id);
    }
}
