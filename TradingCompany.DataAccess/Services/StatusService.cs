using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Services
{
    public class StatusService : IStatusService
    {
        private readonly IMapper _mapper;
        public StatusService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<StatusDTO> GetAllStatus()
        {
            using (var e = new DataContext())
            {
                return _mapper.Map<List<StatusDTO>>(e.Status.ToList());

            }
        }

        public StatusDTO GetStatus(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Status.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<StatusDTO>(m);
            }
        }
    }
}