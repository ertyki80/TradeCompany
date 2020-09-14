using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
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
