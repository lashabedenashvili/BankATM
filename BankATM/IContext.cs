using BankATM.Data;
using Microsoft.EntityFrameworkCore;

namespace BankATM
{
    public interface IContext 
    {
        DbSet<Bill> Bill { get; set; }
        DbSet<BlockCard> BlockCard { get; set; }
        DbSet<Card> Card { get; set; }
        DbSet<LogTime> LogTime { get; set; }
        DbSet<Transactions> Transactions { get; set; }
        DbSet<User> User { get; set; }

        int saveChanges();

       
    }
}