using FCBankDemo.DTO;
using MediatR;
using FCBankDemo.Model;

namespace FCBankDemo.Commands
{
    public class WithdrawAccountCommand : IRequest<AccountDTO>
    {
        public WithdrawAccountDTO Account { get; set; } = new WithdrawAccountDTO();
        public WithdrawAccountCommand(WithdrawAccountDTO account)
        {
            Account = account;
        }
    }
}