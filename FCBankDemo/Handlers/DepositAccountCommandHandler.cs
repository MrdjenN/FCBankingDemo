using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using Mapster;
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

            var account = await _accountRepository.GetccountByAccountNumber(cmd.Deposit.AccountNumber);
            if (account == null)
                return new AccountDTO(); // todo: handle account not found -for simplicity

            if (account.SetBalance(account.Balance + cmd.Deposit.Amount))
            {
                _accountRepository.Update(account);
                var res = await _accountRepository.SaveAsync(cancellationToken);
                if(res > 0)
                    return account.Adapt<AccountDTO>();
            }

            //todo: emplty account dto on failure for simplicity
            return new AccountDTO();
        }
    }

    public class DepositAccountCommandValidator : AbstractValidator<DepositAccountCommand>
    {
        public DepositAccountCommandValidator(ILogger<DepositAccountCommandValidator> logger)
        {
            RuleFor(x => x.Deposit.Amount).GreaterThan(0).WithMessage("Deposit amount must be greater than zero.");
            RuleFor(x => x.Deposit.AccountNumber).NotEmpty().WithMessage("Account number must be provided.");
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}