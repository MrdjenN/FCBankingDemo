using FCBankDemo.Common;
using FCBankDemo.DTO;
using MediatR;

namespace FCBankDemo.Commands
{
    public class WithdrawAccountCommand : IRequest<Result<AccountDTO>>
    {


        public WithdrawAccountDTO WithdrawRequest { get; set; } = new WithdrawAccountDTO();
        public WithdrawAccountCommand(WithdrawAccountDTO withdrawRequest)
        {
            WithdrawRequest = withdrawRequest;
        }
    }
}