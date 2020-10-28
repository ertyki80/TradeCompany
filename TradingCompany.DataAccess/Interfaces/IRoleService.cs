using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface IRoleService
    {
        RoleDTO GetRole(int id);
        List<RoleDTO> GetAllRole();


    }
}
