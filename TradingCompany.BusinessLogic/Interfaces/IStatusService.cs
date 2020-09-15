using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Models;

namespace BusinessLogic.Interfaces
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
