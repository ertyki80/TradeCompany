using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDataTransfer
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public string User { get; set; }

        public DateTime Time { get; set; }

        public string Status { get; set; }

        public DateTime TimeOfChange { get; set; }

    }
}
