using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Services
{

    public class LogsService : ILogsService
    {
        private readonly IMapper _mapper;
        public LogsService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public LogsDTO Create(LogsDTO logs)
        {
            using (var entities = new DataContext())
            {
                Logs m = _mapper.Map<Logs>(logs);
                entities.Logs.Add(m);
                entities.SaveChanges();

                return _mapper.Map<LogsDTO>(m);
            }
        }

        public IEnumerable<LogsDTO> GetAllLogs()
        {
            using (var e = new DataContext())
            {
                return _mapper.Map<List<LogsDTO>>(e.Logs.ToList());

            }
        }

        public LogsDTO GetLogs(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Logs.SingleOrDefault(mm => mm.Id == id);
                return _mapper.Map<LogsDTO>(m);
            }
        }


    }
}
