using MediatR;

namespace FCBankDemo.Commands
{
    public class GetAccountBallanceCommand : IRequest<decimal>
    {
        public string AccountNumber { get; set; } = string.Empty;
        public GetAccountBallanceCommand(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}