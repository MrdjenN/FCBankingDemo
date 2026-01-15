using FCBankDemo.Model;

namespace FCBankDemo.Reposiitories
{
    public interface IAccountRepository : IAccountQuery
    {
        Account Add(Account account);
        void Add(List<Account> accounts);
        Account Update(Account account);
        Task<int> SaveAsync(CancellationToken cancellation);
    }
}
