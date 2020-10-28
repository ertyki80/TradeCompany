using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface IStatusService
    {

        StatusDTO GetStatus(int id);
        List<StatusDTO> GetAllStatus();

    }
}
