using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.DataAccess.Query
{
    public class GetUserQuery
    {
        private readonly DataContext _context;

        public GetUserQuery(DataContext context)
        {
            context = _context;
        }

        public IList<User> Execute()
        {
            return _context.Users.OrderBy(c => c.Login).ToList();
        }
    }
}
