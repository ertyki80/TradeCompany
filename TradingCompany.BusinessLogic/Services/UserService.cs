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

        public UserService(DataContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            var encryptionHash = new EncryptionHash();
            user.Password = encryptionHash.EncodePassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }



        public void Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {

                _context.Users.Remove(user);
            }

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

            _context.SaveChanges();
        }
    }
}