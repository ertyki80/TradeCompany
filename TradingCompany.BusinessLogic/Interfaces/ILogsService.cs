using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface ILogsService
    {
        Logs GetLogs(int id);
        IEnumerable<Logs> GetAllLogs();
        void Create(Logs logs);
        void Update(int id, Logs logs);
        void Delete(int id);

    }
}
