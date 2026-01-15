using FCBankDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace FCBankDemo.Reposiitories
{
    public class AccountQuery : IAccountQuery
    {
        private readonly BankingDBContext _context;

        public AccountQuery(BankingDBContext context)
        {
            _context = context;
        }

        public Task<List<Account>> GetAccounts(IList<string> accountIds)
        {
            return _context.Accounts.Where(x => accountIds.Contains(x.AccountNumber)).ToListAsync();
        }

        public Task<List<Account>> GetAllAccounts()
        {
            return _context.Accounts.ToListAsync();
        }
    }
}
