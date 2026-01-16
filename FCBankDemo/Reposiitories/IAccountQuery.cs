using FCBankDemo.Model;

namespace FCBankDemo.Reposiitories
{
    public interface IAccountQuery
    {
        Task<Account?> GetccountByAccountNumber(string accountNumber);
    }
}
