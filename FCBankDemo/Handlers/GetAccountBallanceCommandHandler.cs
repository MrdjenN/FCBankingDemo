using FCBankDemo.Commands;
using FCBankDemo.Common;
using FCBankDemo.Reposiitories;
using FluentValidation;
using MediatR;

namespace FCBankDemo.Handlers
{

    public class GetAccountBallanceCommandHandler : IRequestHandler<GetAccountBallanceCommand, Result<decimal>>
    {
        private readonly ILogger<GetAccountBallanceCommandHandler> _logger;
        private readonly IAccountQuery _accountQuery;

        public GetAccountBallanceCommandHandler(ILogger<GetAccountBallanceCommandHandler> logger, IAccountQuery accountQuery)
        {
            _logger = logger;
            _accountQuery = accountQuery;
        }

        public async Task<Result<decimal>> Handle(GetAccountBallanceCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAccountBallanceCommand: Cmd = {@Cmd}.", cmd);
            

            var account = await _accountQuery.GetccountByAccountNumber(cmd.AccountNumber);
            if (account == null)
                return Result<decimal>.Failure("Account not found");
            
            return Result<decimal>.Success(account.Balance);
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