using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class DepositAccountCommandHandler : IRequestHandler<DepositAccountCommand, AccountDTO>
    {
        private readonly ILogger<DepositAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public DepositAccountCommandHandler(ILogger<DepositAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<AccountDTO> Handle(DepositAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DepositAccountCommand: Cmd = {@Cmd}.", cmd);
            
            return new AccountDTO();
        }
    }

    public class DepositAccountCommandValidator : AbstractValidator<DepositAccountCommand>
    {
        public DepositAccountCommandValidator(ILogger<DepositAccountCommandValidator> logger)
        {
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}