using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    interface IStatusService
    {

        StatusDTO GetStatus(int id);
        IEnumerable<StatusDTO> GetAllStatus();

    }
}
