using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Interfaces
{
    interface IRoleService
    {
        Role GetRole(int id);
        IEnumerable<Role> GetAllRole();
        void Create(Role role);
        void Update(int id, Role role);
        void Delete(int id);
        

    }
}
