using FCBankDemo.DTO;
using MediatR;

namespace FCBankDemo.Commands
{
    public class TransferAccountCommand : IRequest<bool>
    {
        public TransferAccountDTO TransferRequest { get; set; } = new TransferAccountDTO();
        public TransferAccountCommand(TransferAccountDTO transferRequest)
        {
            TransferRequest = transferRequest;
        }
    }
}