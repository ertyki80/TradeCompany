using System.Collections.Generic;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Interfaces
{
    interface IStatusService
    {

        Status GetStatus(int id);
        IEnumerable<Status> GetAllStatus();
        void Create(Status status);
        void Update(int id, Status status);
        void Delete(int id);
    }
}
