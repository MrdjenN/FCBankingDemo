using FCBankDemo.Commands;
using FCBankDemo.Common;
using FCBankDemo.DTO;
using FCBankDemo.Reposiitories;
using FluentValidation;
using Mapster;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class DepositAccountCommandHandler : IRequestHandler<DepositAccountCommand, Result<AccountDTO>>
    {
        private readonly ILogger<DepositAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public DepositAccountCommandHandler(ILogger<DepositAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<Result<AccountDTO>> Handle(DepositAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DepositAccountCommand: Cmd = {@Cmd}.", cmd);


            var account = await _accountRepository.GetccountByAccountNumber(cmd.DepositRequest.AccountNumber);
            if (account == null)
                return Result<AccountDTO>.Failure("Account not found");

            
            if (account.SetBalance(account.Balance + cmd.DepositRequest.Amount))
            {
                _accountRepository.Update(account);
                var res = await _accountRepository.SaveAsync(cancellationToken);
                if (res > 0)
                    return Result<AccountDTO>.Success(account.Adapt<AccountDTO>());
            }


            return Result<AccountDTO>.Failure("Failed to deposit");
        }
    }

    public class DepositAccountCommandValidator : AbstractValidator<DepositAccountCommand>
    {
        public DepositAccountCommandValidator(ILogger<DepositAccountCommandValidator> logger)
        {
            RuleFor(x => x.DepositRequest.Amount).GreaterThan(0); ;
            RuleFor(x => x.DepositRequest.AccountNumber).NotEmpty();
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}