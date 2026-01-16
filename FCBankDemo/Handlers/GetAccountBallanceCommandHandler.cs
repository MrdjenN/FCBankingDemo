using FCBankDemo.Commands;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class GetAccountBallanceCommandHandler : IRequestHandler<GetAccountBallanceCommand, decimal>
    {
        private readonly ILogger<GetAccountBallanceCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public GetAccountBallanceCommandHandler(ILogger<GetAccountBallanceCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<decimal> Handle(GetAccountBallanceCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAccountBallanceCommand: Cmd = {@Cmd}.", cmd);
            
            return 0;
        }
    }

    public class GetAccountBallanceCommandValidator : AbstractValidator<GetAccountBallanceCommand>
    {
        public GetAccountBallanceCommandValidator(ILogger<GetAccountBallanceCommandValidator> logger)
        {
            RuleFor(command => command.AccountNumber).NotEmpty();
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}