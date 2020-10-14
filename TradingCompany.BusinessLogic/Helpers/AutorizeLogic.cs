using System;
using System.Linq;
using TradingCompany.BusinessLogic.Encription;
using TradingCompany.BusinessLogic.Services;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Helpers
{
    public class AutorizeLogic
    {
        public bool UserRecognition = false;

        private User _currentUser;

        public bool Login(string login, string password)
        {
            using (var db = new DataContext())
            {
                var userService = new UserService(db);
                var encryptionHash = new EncryptionHash();
                var passwordEncoding = encryptionHash.EncodePassword(password);
                var user = db.Users.FirstOrDefault(b => b.Login == login && b.Password == passwordEncoding);
                UserRecognition = user != null;
                _currentUser = user;
                return UserRecognition;
            }
        }

        public User GetUser()
        {
            return _currentUser;

        }
        public void Registration(string login, string password, string role, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            using (var db = new DataContext())
            {
                Role nRole = new Role(){Name=role};
                var userService = new UserService(db);
                if (login.Length > 12 && password.Length > 14 && firstName.Length > 12 && lastName.Length > 12)
                {
                    return;
                }
                var newUser = new User()
                {
                    
                    Login = login,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Role = nRole,
                    TimeOfCreating = DateTime.Now
                };
                _currentUser = newUser;
                userService.Create(newUser);
            }


        }
    }
}
