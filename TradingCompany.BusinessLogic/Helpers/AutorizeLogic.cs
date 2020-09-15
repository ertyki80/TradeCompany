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
        public bool Login(string login, string password)
        {
            using (var db = new DataContext())
            {
                var userService = new UserService(db);
                var encryptionHash = new EncryptionHash();
                var passwordEncoding = encryptionHash.EncodePassword(password);
                var user = db.Users.FirstOrDefault(b => b.Login == login && b.Password == passwordEncoding);

                UserRecognition = user != null;
                return UserRecognition;
            }


        }
        public void Registration(string login, string password, Role role, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            using (var db = new DataContext())
            {
                var userService = new UserService(db);
                var newUser = new User()
                {
                    Login = login,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Role = role
                };

                userService.Create(newUser);
            }


        }
    }
}
