using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDataTransfer.ModelDTO
{
   public  class transactionNDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
    }
}
