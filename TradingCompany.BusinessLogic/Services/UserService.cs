using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Encription;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly LogsService logsService;

        public UserService(DataContext context)
        {
            logsService = new LogsService(context);
            _context = context;
        }
        public void Create(User user)
        {
            var encryptionHash = new EncryptionHash();
            user.Password = encryptionHash.EncodePassword(user.Password);
            _context.Users.Add(user);
            Logs logs = new Logs() { Name = "Create a new User", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }



        public void Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {

                _context.Users.Remove(user);
            }
            Logs logs = new Logs() { Name = "Delete a User", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user ?? null;
        }


        public void Update(int id, User user)
        {
            var oldUser = _context.Users.Find(id);
            if (oldUser != null && user != null)
            {

                _context.Users.Remove(oldUser);
                _context.Users.Add(user);
            }
            Logs logs = new Logs() { Name = "Update a User", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }
    }
}