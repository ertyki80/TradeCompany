using System;

namespace TradingCompany.BusinessLogic.Interfaces
{
    public interface IAuthManager
    {
        bool Login(string username, string password);
        bool Registration(string login, string password, string firstName, string lastName, DateTime dateOfBirth, string email);
        int GetId(string login);
    }
}
