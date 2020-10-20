using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.BusinessLogic.Encription;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Mapper;
using TradingCompany.DataAccess.Models;
using TradingCompany.DataAccess.Services;
using TradingCompanyDataTransfer;

namespace TradingCompany.BusinessLogic.Helpers
{
    public class AutorizeLogic
    {
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                mc => mc.AddProfile(new UserProfile())
            );

            return conf.CreateMapper();
        }

        private  IMapper mapper;

        public bool UserRecognition = false;

        private UserDTO _currentUser;

        public AutorizeLogic()
        {
            mapper = SetupMapper();
        }

        public bool Login(string login, string password)
        {
            var userService = new UserService(mapper);
            var encryptionHash = new EncryptionHash();
            var passwordEncoding = encryptionHash.EncodePassword(password);
            IEnumerable<UserDTO> db = userService.GetAllUsers();
            var user = db.FirstOrDefault(b => b.Login == login && b.Password == passwordEncoding);
            if (user != null)
            {
                _currentUser = user;
                UserRecognition = true;
            }
            return UserRecognition;

        }

        public UserDTO GetUser()
        {
            return _currentUser;

        }

        public void Registration(string login, string password, string role, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            var encryptionHash = new EncryptionHash();
            var passwordEncoding = encryptionHash.EncodePassword(password);
            var userService = new UserService(mapper);
            IEnumerable<UserDTO> db = userService.GetAllUsers();
            var user = db.FirstOrDefault(b => b.Login == login && b.Password == passwordEncoding);
            if (user == null)
            {
                RoleDTO nRole = new RoleDTO() { Name = role };
                if (login.Length > 12 && password.Length > 14 && firstName.Length > 12 && lastName.Length > 12)
                {
                    return;
                }
                var newUser = new UserDTO()
                {

                    Login = login,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Password = passwordEncoding,
                    RoleDTO = nRole,
                    TimeOfCreating = DateTime.Now
                };
                _currentUser = newUser;
                userService.Create(newUser);
            }
            else
            {
                _currentUser = user;

            }
        }
    }
}
