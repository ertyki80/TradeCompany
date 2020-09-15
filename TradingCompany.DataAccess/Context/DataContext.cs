using System.Data.Entity;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.DataAccess.Context
{
    public class DataContext:DbContext
    {
        public DataContext()
           : base("DBConnection")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Logs> Logs { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
