using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class TransferAccountCommandHandler : IRequestHandler<TransferAccountCommand, bool>
    {
        private readonly ILogger<TransferAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public TransferAccountCommandHandler(ILogger<TransferAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<bool> Handle(TransferAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TransferAccountCommand: Cmd = {@Cmd}.", cmd);


            // note: we can optimize by fething both accounts
            var sourceAccount = await _accountRepository.GetccountByAccountNumber(cmd.TransferRequest.SourceAccountNumber);
            if (sourceAccount == null)
                return false; // can return propper error withh explanation - for simplicity just bool

            var dstAccount = await _accountRepository.GetccountByAccountNumber(cmd.TransferRequest.DestinationAccountNumber);
            if (dstAccount == null)
                return false;

            if (sourceAccount.Balance < cmd.TransferRequest.Amount)
                return false;

            var newSourceBalance = sourceAccount.Balance - cmd.TransferRequest.Amount;
            var newDstBalance = dstAccount.Balance + cmd.TransferRequest.Amount;

            var updateSourceResult = sourceAccount.SetBalance(newSourceBalance);
            if (!updateSourceResult)
                return false;

            var updateDstResult = dstAccount.SetBalance(newDstBalance);
            if (!updateDstResult)
                return false;

            _accountRepository.Update(sourceAccount);
            _accountRepository.Update(dstAccount);

            var updateDBResponse = await _accountRepository.SaveAsync(cancellationToken);
            if (updateDBResponse > 0)
                return true;


            return false;
        }
    }

    public class TransferAccountCommandValidator : AbstractValidator<TransferAccountCommand>
    {
        public TransferAccountCommandValidator(ILogger<TransferAccountCommandValidator> logger)
        {
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}