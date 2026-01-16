using FCBankDemo.DTO;
using MediatR;

namespace FCBankDemo.Commands
{
    public class TransferAccountCommand : IRequest<bool>
    {
        public TransferAccountDTO Account { get; set; } = new TransferAccountDTO();
        public TransferAccountCommand(TransferAccountDTO account)
        {
            Account = account;
        }
    }
}