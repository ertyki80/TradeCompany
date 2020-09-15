using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    internal interface ILogsService
    {
        Logs GetLogs(int id);
        IEnumerable<Logs> GetAllLogs();
        void Create(Logs logs);
        void Update(int id, Logs logs);
        void Delete(int id);

    }
}
