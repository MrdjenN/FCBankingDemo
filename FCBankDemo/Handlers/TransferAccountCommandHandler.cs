using FCBankDemo.Commands;
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