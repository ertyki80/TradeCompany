using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public int CountInStock { get; set; }

        public DateTime TimeOfAdd { get; set; }

    }
}
