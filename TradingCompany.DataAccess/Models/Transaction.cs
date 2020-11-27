using System;

namespace TradingCompany.DataAccess.Models {

    public class Transaction
    {

        public int Id { get; set; }

        public string Product { get; set; }

        public string User { get; set; }

        public DateTime Time { get; set; }

        public string Status { get; set; }

        public DateTime TimeOfChange { get; set; }

    }
}
