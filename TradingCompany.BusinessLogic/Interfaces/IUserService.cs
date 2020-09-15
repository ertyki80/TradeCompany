using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Interfaces
{
    interface IUserService
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        void Create(User user);
        void Update(int id, User user);
        void Delete(int id);
    }
}
