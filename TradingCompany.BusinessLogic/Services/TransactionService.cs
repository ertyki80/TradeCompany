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
        private LogsService logsService;


        public TransactionService(DataContext context)
        {
            logsService = new LogsService(context);
            _context = context;
        }

        public void Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);

            Logs logs = new Logs() { Name = "Create a new Transaction", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var transaction = _context.Transactions.Find(id);

            if (transaction == null)
            {
            }
            _context.Transactions.Remove(transaction ?? throw new InvalidOperationException("transaction is null"));

            Logs logs = new Logs() { Name = "Delete a Category", Time = DateTime.Now };
            logsService.Create(logs);
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

            Logs logs = new Logs() { Name = "Update a Category", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }
    }
}