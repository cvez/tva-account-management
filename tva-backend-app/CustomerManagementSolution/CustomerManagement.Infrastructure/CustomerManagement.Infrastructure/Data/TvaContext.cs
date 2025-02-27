using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Infrastructure.Data
{
    public class TvaContext : DbContext
    {
        public TvaContext(DbContextOptions<TvaContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
