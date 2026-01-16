using FCBankDemo.DTO;
using MediatR;
using FCBankDemo.Model;
using FCBankDemo.Controllers;

namespace FCBankDemo.Commands
{
    public class DepositAccountCommand : IRequest<AccountDTO>
    {
        public DepositAccountDTO Account { get; set; } = new DepositAccountDTO();
        public DepositAccountCommand(DepositAccountDTO account)
        {
            Account = account;
        }
    }
}