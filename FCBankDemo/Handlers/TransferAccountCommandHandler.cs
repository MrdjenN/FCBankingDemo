using FCBankDemo.Commands;
using FCBankDemo.Common;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class TransferAccountCommandHandler : IRequestHandler<TransferAccountCommand, Result<bool>>
    {
        private readonly ILogger<TransferAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public TransferAccountCommandHandler(ILogger<TransferAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<Result<bool>> Handle(TransferAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("TransferAccountCommand: Cmd = {@Cmd}.", cmd);

            // note: we can optimize by fething both accounts - for simplicity I did it one by one here
            var sourceAccount = await _accountRepository.GetccountByAccountNumber(cmd.TransferRequest.SourceAccountNumber);
            
            if (sourceAccount == null)
                return Result<bool>.Failure("Source account not found");

            var dstAccount = await _accountRepository.GetccountByAccountNumber(cmd.TransferRequest.DestinationAccountNumber);
            if (dstAccount == null)
                return Result<bool>.Failure("Destination account not found");

            if (sourceAccount.Balance < cmd.TransferRequest.Amount)
                return Result<bool>.Failure("Insufficient funds in source account");

            var newSourceBalance = sourceAccount.Balance - cmd.TransferRequest.Amount;
            var newDstBalance = dstAccount.Balance + cmd.TransferRequest.Amount;

            var updateSourceResult = sourceAccount.SetBalance(newSourceBalance);
            if (!updateSourceResult)
                return Result<bool>.Failure("Failed to update source account balance");

            var updateDstResult = dstAccount.SetBalance(newDstBalance);
            if (!updateDstResult)
                return Result<bool>.Failure("Failed to update destination account balance");


            _accountRepository.Update(sourceAccount);
            _accountRepository.Update(dstAccount);


            var updateDBResponse = await _accountRepository.SaveAsync(cancellationToken);
            if (updateDBResponse > 0)
                return Result<bool>.Success(true);


            return Result<bool>.Failure("Failed ransfer");
        }
    }

    public class TransferAccountCommandValidator : AbstractValidator<TransferAccountCommand>
    {
        public TransferAccountCommandValidator(ILogger<TransferAccountCommandValidator> logger)
        {
            RuleFor(command => command.TransferRequest.SourceAccountNumber).NotEmpty();
            RuleFor(command => command.TransferRequest.DestinationAccountNumber).NotEmpty();
            RuleFor(command => command.TransferRequest.Amount).GreaterThan(0);
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}