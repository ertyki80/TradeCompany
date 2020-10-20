using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        public TransactionService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TransactionDTO Create(TransactionDTO transaction)
        {
            using (var entities = new DataContext())
            {
                Transaction m = _mapper.Map<Transaction>(transaction);
                entities.Transactions.Add(m);
                entities.SaveChanges();
                return _mapper.Map<TransactionDTO>(m);

            }
        }

        public void Delete(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Transactions.SingleOrDefault(mm => mm.Id == id);
                if (m == null)
                {
                    return;
                }
                entities.Transactions.Remove(m);
                entities.SaveChanges();

            }
        }

        public IEnumerable<TransactionDTO> GetAllTransactions()
        {
            using (var e = new DataContext())
            {
                return _mapper.Map<List<TransactionDTO>>(e.Transactions.ToList());

            }
        }

        public TransactionDTO GetTransaction(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Transactions.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<TransactionDTO>(m);
            }
        }

        public void Update(int id, TransactionDTO transaction)
        {
            using (var entity = new DataContext())
            {
                Transaction m = _mapper.Map<Transaction>(transaction);
                entity.Transactions.AddOrUpdate(m);
                entity.SaveChanges();
            }
        }
    }
}