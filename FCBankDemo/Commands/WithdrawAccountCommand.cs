using FCBankDemo.DTO;
using MediatR;
using FCBankDemo.Model;

namespace FCBankDemo.Commands
{
    public class WithdrawAccountCommand : IRequest<AccountDTO>
    {
        public WithdrawAccountDTO WithdrawRequest { get; set; } = new WithdrawAccountDTO();
        public WithdrawAccountCommand(WithdrawAccountDTO withdrawRequest)
        {
            WithdrawRequest = withdrawRequest;
        }
    }
}