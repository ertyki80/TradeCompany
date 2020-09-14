using BusinessLogic.Encription;
using BusinessLogic.Services;
using DataAccess;
using System;
using System.Linq;

namespace BusinessLogic.Helper
{
    class AutorizeLogic
    {
        public bool userRecognition = false;
        public bool login(string login, string password)
        {
            using (DataContext db = new DataContext())
            {
                UserService userService = new UserService(db);
                EncryptionHASH encryptionHASH = new EncryptionHASH();
                string passwordEncoding = encryptionHASH.EncodePassword(password);
                var user = db.Users.Where(b => b.Login == login && b.Password == passwordEncoding).FirstOrDefault();

                if (user != null)
                {
                    userRecognition = true;
                }
                else
                {
                    userRecognition = false;

                }
                return userRecognition;
            }


        }
        public void registration(string login, string password, Role role, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            using (DataContext db = new DataContext())
            {
                UserService userService = new UserService(db);
                User newUser = new User()
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
