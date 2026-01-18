using FCBankDemo.Common;
using FCBankDemo.DTO;
using MediatR;

namespace FCBankDemo.Commands
{
    public class DepositAccountCommand : IRequest<Result<AccountDTO>>
    {
        public DepositAccountDTO DepositRequest { get; set; } = new DepositAccountDTO();
        
        
        public DepositAccountCommand(DepositAccountDTO deposit)
        {
            DepositRequest = deposit;
        }
    }
}