using FCBankDemo.Migrations;
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

        public async Task<Account?> GetccountByAccountNumber(string accountNumber)
        {
            return _context.Accounts.Where(x => x.AccountNumber == accountNumber).FirstOrDefault();
        }

    }
}
