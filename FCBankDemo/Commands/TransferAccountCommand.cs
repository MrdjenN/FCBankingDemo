using FCBankDemo.Common;
using FCBankDemo.DTO;
using MediatR;

namespace FCBankDemo.Commands
{
    public class TransferAccountCommand : IRequest<Result<bool>>
    {
        public TransferAccountDTO TransferRequest { get; set; } = new TransferAccountDTO();
        public TransferAccountCommand(TransferAccountDTO transferRequest)
        {
            TransferRequest = transferRequest;
        }
    }
}