using Microsoft.EntityFrameworkCore;

namespace FCBankDemo.Model
{
    public class BankingDBContext: DbContext
    {
        public BankingDBContext(DbContextOptions<BankingDBContext> options) :
            base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
