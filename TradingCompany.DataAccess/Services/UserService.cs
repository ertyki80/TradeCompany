﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TradingCompany.BusinessLogic.Encription;
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

        public List<UserDTO> GetAllUsers()
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

        public bool Login(string username, string password)
        {
            using (var ent = new DataContext())
            {
                User user = ent.Users.SingleOrDefault(u => u.Login == username);
                EncryptionHash encryptionHash = new EncryptionHash();
                return user != null && user.Password == encryptionHash.EncodePassword(password);
            }
        }

        public bool Registration(string login, string password, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            using (var entities = new DataContext())
            {
                User user = entities.Users.SingleOrDefault(u => u.Login == login);
                EncryptionHash encryptionHash = new EncryptionHash();
                IRoleService roleService = new RoleService(_mapper);
                if (user == null)
                {
                    User u = new User()
                    {
                        Login = login,
                        DateOfBirth = dateOfBirth,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Password =encryptionHash.EncodePassword(password),
                        Role = _mapper.Map<Role>(roleService.GetRole(1)),
                        TimeOfCreating = DateTime.Now

                    };
                    entities.Users.Add(user);
                    entities.SaveChanges();
                    user = u;
                }
                return user != null;
            }
        }

        public UserDTO Update(int id, UserDTO user)
        {
            
            using (var entity = new DataContext())
            {
                var _user = entity.Users.SingleOrDefault(u => u.Id == id);
                if (_user == null)
                {
                    user.TimeOfCreating = DateTime.UtcNow;
                    _user = _mapper.Map<User>(user);
                    entity.Users.Add(_user);
                }
                else
                {
                    user.TimeOfCreating = DateTime.UtcNow;
                    _mapper.Map(user, _user);
                }
                entity.SaveChanges();
                return _mapper.Map<UserDTO>(user);
            }
        }
    }
}