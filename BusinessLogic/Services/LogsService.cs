using BusinessLogic.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
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

            if (log == null)
            {
            }
            _context.Logs.Remove(log);

            _context.SaveChanges();
        }

        public IEnumerable<Logs> GetAllLogs()
        {
            return _context.Logs;
        }

        public Logs GetLogs(int id)
        {
            var log = _context.Logs.Find(id);
            if (log != null)
            {
                return log;
            }
            return null;
        }

        public void Update(int id, Logs logs)
        {
            var oldlog = _context.Logs.Find(id);
            if (oldlog != null && logs != null)
            {

                _context.Logs.Remove(oldlog);
                _context.Logs.Add(logs);
            }

            _context.SaveChanges();
        }
    }
}
