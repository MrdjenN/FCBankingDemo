using FCBankDemo.DTO;
using MediatR;

namespace FCBankDemo.Commands
{
    public class CreateAccountCommand : IRequest<AccountDTO>
    {
        public CreateAccountDTO AccountRequest { get; set; } = new CreateAccountDTO();
        public CreateAccountCommand(CreateAccountDTO account)
        {
            AccountRequest = account;
        }
    }
}
