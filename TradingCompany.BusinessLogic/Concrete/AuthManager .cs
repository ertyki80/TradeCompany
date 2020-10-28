using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Interfaces;

namespace TradingCompany.BusinessLogic
{
    public class AuthManager : IAuthManager
    {
        private readonly IUserService _userDal;
        public AuthManager(IUserService userDal)
        {
            _userDal = userDal;
        }

        public int GetId(string login)
        {
            return _userDal.GetId(login);
        }

        public bool Login(string username, string password)
        {
            return _userDal.Login(username, password);

        }

        public bool Registration(string login, string password, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            return _userDal.Registration(login,  password,  firstName,  lastName,  dateOfBirth,  email);
        }

    }
}
