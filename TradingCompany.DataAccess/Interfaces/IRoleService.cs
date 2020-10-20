using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    interface IRoleService
    {
        RoleDTO GetRole(int id);
        IEnumerable<RoleDTO> GetAllRole();


    }
}
