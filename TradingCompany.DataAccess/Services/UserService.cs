using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDTO Create(UserDTO user)
        {
            using (var entities = new DataContext())
            {
                User m = _mapper.Map<User>(user);
                entities.Users.Add(m);
                entities.SaveChanges();
                    
                return _mapper.Map<UserDTO>(m);
            }
        }

        public void Delete(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Users.SingleOrDefault(mm => mm.Id == id);

                if (m == null)
                {
                    return;
                }
                entities.Users.Remove(m);
                entities.SaveChanges();
            }
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            using (var e = new DataContext())
            {
                return _mapper.Map<List<UserDTO>>(e.Users.ToList());

            }
        }

        public UserDTO GetUser(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Users.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<UserDTO>(m);
            }
        }

        public void Update(int id, UserDTO user)
        {
            using (var entity = new DataContext())
            {

                User m = _mapper.Map<User>(user);
                entity.Users.AddOrUpdate(m);
                entity.SaveChanges();
            }
        }
    }
}