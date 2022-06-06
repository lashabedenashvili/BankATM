using System;
using BankATM.Data;
using Microsoft.EntityFrameworkCore;

namespace BankATM
{
    public class Context : DbContext, IContext
    {
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BlockCard> BlockCard { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<LogTime> LogTime { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-BT9G1PG\GK;Database=EF_ATM;integrated security=sspi");
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BT9G1PG\GK;Initial Catalog=BankATM;Integrated Security=True");

        }
    }
}
