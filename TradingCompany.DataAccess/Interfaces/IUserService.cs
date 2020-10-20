using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    interface IUserService
    {
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO Create(UserDTO user);
        void Update(int id, UserDTO user);
        void Delete(int id);
    }
}
