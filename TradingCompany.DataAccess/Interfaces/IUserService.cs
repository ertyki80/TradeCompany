using System;
using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        List<UserDTO> GetAllUsers();
        UserDTO Create(UserDTO user);
        UserDTO Update(int id, UserDTO user);
        void Delete(int id);
        bool Login(string username, string password);
        bool Registration(string login, string password, string firstName, string lastName, DateTime dateOfBirth, string email);
        int GetId(string login);
    }   
}
