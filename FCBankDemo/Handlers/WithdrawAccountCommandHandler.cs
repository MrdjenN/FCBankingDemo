using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class WithdrawAccountCommandHandler : IRequestHandler<WithdrawAccountCommand, AccountDTO>
    {
        private readonly ILogger<WithdrawAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public WithdrawAccountCommandHandler(ILogger<WithdrawAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<AccountDTO> Handle(WithdrawAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("WithdrawAccountCommand: Cmd = {@Cmd}.", cmd);
            
            return new AccountDTO();
        }
    }

    public class WithdrawAccountCommandValidator : AbstractValidator<WithdrawAccountCommand>
    {
        public WithdrawAccountCommandValidator(ILogger<WithdrawAccountCommandValidator> logger)
        {
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}