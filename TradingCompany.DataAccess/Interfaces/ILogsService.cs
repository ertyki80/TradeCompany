using System.Collections.Generic;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Interfaces
{
    public interface ILogsService
    {
        LogsDTO GetLogs(int id);
        List<LogsDTO> GetAllLogs();
        LogsDTO Create(LogsDTO logs);

    }
}
