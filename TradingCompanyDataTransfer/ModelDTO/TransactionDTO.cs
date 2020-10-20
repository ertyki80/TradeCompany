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

        public ProductDTO Product { get; set; }

        public UserDTO User { get; set; }

        public DateTime Time { get; set; }

        public StatusDTO Status { get; set; }

        public DateTime TimeOfChange { get; set; }

    }
}
