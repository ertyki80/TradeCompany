using BusinessLogic.Encription;
using BusinessLogic.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
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
            EncryptionHASH encryptionHASH = new EncryptionHASH();
            user.Password = encryptionHASH.EncodePassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }



        public void Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
            }
            _context.Users.Remove(user);

            _context.SaveChanges();

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            return null;

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