using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        public RoleService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<RoleDTO> GetAllRole()
        {
            using (var e = new DataContext())
            {
                return _mapper.Map<List<RoleDTO>>(e.Roles.ToList());

            }
        }

        public RoleDTO GetRole(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Roles.SingleOrDefault(mm => mm.Id == id);
                return _mapper.Map<RoleDTO>(m);

            }
        }
    }
}