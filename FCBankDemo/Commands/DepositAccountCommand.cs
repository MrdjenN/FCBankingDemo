using FCBankDemo.DTO;
using MediatR;
using FCBankDemo.Model;

namespace FCBankDemo.Commands
{
    public class DepositAccountCommand : IRequest<AccountDTO>
    {
        public DepositAccountDTO Deposit { get; set; } = new DepositAccountDTO();
        public DepositAccountCommand(DepositAccountDTO deposit)
        {
            Deposit = deposit;
        }
    }
}