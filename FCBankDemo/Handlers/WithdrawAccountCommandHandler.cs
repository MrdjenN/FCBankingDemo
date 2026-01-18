using FCBankDemo.Commands;
using FCBankDemo.Common;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using Mapster;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class WithdrawAccountCommandHandler : IRequestHandler<WithdrawAccountCommand, Result<AccountDTO>>
    {
        private readonly ILogger<WithdrawAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public WithdrawAccountCommandHandler(ILogger<WithdrawAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<Result<AccountDTO>> Handle(WithdrawAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("WithdrawAccountCommand: Cmd = {@Cmd}.", cmd);
            var account = await _accountRepository.GetccountByAccountNumber(cmd.WithdrawRequest.AccountNumber);
            if (account == null)
                return Result<AccountDTO>.Failure("Account not found");


            //check balance
            if (account.Balance < cmd.WithdrawRequest.Amount)
                return Result<AccountDTO>.Failure("Insufficient funds");

            
            if (account.SetBalance(account.Balance - cmd.WithdrawRequest.Amount))
            {
                _accountRepository.Update(account);
                var res = await _accountRepository.SaveAsync(cancellationToken);
                if (res > 0)
                    return Result<AccountDTO>.Success(account.Adapt<AccountDTO>());
            }
            
            return Result<AccountDTO>.Failure("Failed to withdraw amount");

        }
    }

    public class WithdrawAccountCommandValidator : AbstractValidator<WithdrawAccountCommand>
    {
        public WithdrawAccountCommandValidator(ILogger<WithdrawAccountCommandValidator> logger)
        {
            RuleFor(x => x.WithdrawRequest.Amount).GreaterThan(0);
            RuleFor(x => x.WithdrawRequest.AccountNumber).NotEmpty();
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}