using FCBankDemo.Model;

namespace FCBankDemo.Reposiitories
{
    public interface IAccountQuery
    {
        Task<List<Account>> GetAllAccounts();
        Task<List<Account>> GetAccounts(IList<string> accountIds);
    }
}
