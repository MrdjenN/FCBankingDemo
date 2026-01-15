using FCBankDemo.Model;

namespace FCBankDemo.Reposiitories
{
    public class AccountRepository : AccountQuery, IAccountRepository
    {
        private readonly BankingDBContext _context;
        public AccountRepository(BankingDBContext context) : base(context)
        {
            _context = context;
        }

        public Account Add(Account account)
        {
            return _context.Set<Account>().Add(account).Entity;
        }

        public void Add(List<Account> accounts)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public Account Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
