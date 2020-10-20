using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    internal interface ILogsService
    {
        LogsDTO GetLogs(int id);
        IEnumerable<LogsDTO> GetAllLogs();
        LogsDTO Create(LogsDTO logs);

    }
}
