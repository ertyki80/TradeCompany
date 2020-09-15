using System.Collections.Generic;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class LogsService:ILogsService
    {
        private readonly DataContext _context;

        public LogsService(DataContext context)
        {
            _context = context;
        }

        public void Create(Logs logs)
        {
            _context.Logs.Add(logs);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var log = _context.Logs.Find(id);

            if (log != null)
            {
                _context.Logs.Remove(log);
            }

            _context.SaveChanges();
        }

        public IEnumerable<Logs> GetAllLogs()
        {
            return _context.Logs;
        }

        public Logs GetLogs(int id)
        {
            var log = _context.Logs.Find(id);
            return log ?? null;
        }

        public void Update(int id, Logs logs)
        {
            var oldLogs = _context.Logs.Find(id);
            if (oldLogs != null && logs != null)
            {

                _context.Logs.Remove(oldLogs);
                _context.Logs.Add(logs);
            }

            _context.SaveChanges();
        }
    }
}
