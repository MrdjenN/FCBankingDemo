using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using Mapster;
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
            var account = await _accountRepository.GetccountByAccountNumber(cmd.WithdrawRequest.AccountNumber);
            if (account == null)
                return new AccountDTO(); // todo: handle account not found -for simplicity

            //check balance
            if (account.Balance < cmd.WithdrawRequest.Amount)
                return new AccountDTO(); // todo: handle insufficient funds -for simplicity returns empty dto



            if (account.SetBalance(account.Balance - cmd.WithdrawRequest.Amount))
            {
                _accountRepository.Update(account);
                var res = await _accountRepository.SaveAsync(cancellationToken);
                if (res > 0)
                    return account.Adapt<AccountDTO>();
            }


            //todo: emplty account dto on failure for simplicity
            return new AccountDTO();
        }
    }

    public class WithdrawAccountCommandValidator : AbstractValidator<WithdrawAccountCommand>
    {
        public WithdrawAccountCommandValidator(ILogger<WithdrawAccountCommandValidator> logger)
        {
            RuleFor(x => x.WithdrawRequest.Amount).GreaterThan(0).WithMessage("Withdraw amount must be greater than zero.");
            RuleFor(x => x.WithdrawRequest.AccountNumber).NotEmpty().WithMessage("Account number must be provided.");
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}