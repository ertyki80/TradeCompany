using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {

    public class Transaction
    {

        public int Id { get; set; }

        public Product Product { get; set; }

        public User User { get; set; }

        public DateTime Time { get; set; }

        public Status Status { get; set; }

        public DateTime TimeOfChange { get; set; }

    }
}
