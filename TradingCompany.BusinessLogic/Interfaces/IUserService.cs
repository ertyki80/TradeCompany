using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Models;

namespace BusinessLogic.Interfaces
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
