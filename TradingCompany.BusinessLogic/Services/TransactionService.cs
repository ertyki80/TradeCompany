using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly DataContext _context;

        public TransactionService(DataContext context)
        {
            _context = context;
        }

        public void Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var transaction = _context.Transactions.Find(id);

            if (transaction == null)
            {
            }
            _context.Transactions.Remove(transaction ?? throw new InvalidOperationException("transaction is null"));

            _context.SaveChanges();
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions;
        }

        public Transaction GetTransaction(int id)
        {
            var transaction = _context.Transactions.Find(id);
            return transaction ?? null;
        }

        public void Update(int id, Transaction transaction)
        {
            var oldTransaction = _context.Transactions.Find(id);
            if (oldTransaction != null && transaction != null)
            {

                _context.Transactions.Remove(oldTransaction);
                _context.Transactions.Add(transaction);
            }

            _context.SaveChanges();
        }
    }
}