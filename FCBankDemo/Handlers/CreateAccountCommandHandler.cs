using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using FCBankDemo.Reposiitories;
using FluentValidation;
using Mapster;
using MediatR;

namespace FCBankDemo.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountDTO>
    {
        private readonly ILogger<CreateAccountCommandHandler> _logger;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(ILogger<CreateAccountCommandHandler> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<AccountDTO> Handle(CreateAccountCommand cmd, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateAccountCommand: Cmd = {@Cmd}.", cmd);


            // check if already exists
            var account = await _accountRepository.GetccountByAccountNumber(cmd.AccountRequest.AccountNumber);
            if (account != null) 
                return new AccountDTO(); // TODO: return error code: Account already exists


            //create
            Account newAccount = new Account(cmd.AccountRequest.AccountName,cmd.AccountRequest.ClientId, AccountStatus.Active, (Currency)cmd.AccountRequest.Currency, cmd.AccountRequest.InitialDeposit, cmd.AccountRequest.AccountNumber);
            var resAcc = _accountRepository.Add(newAccount);


            //save
            var saveResult = await _accountRepository.SaveAsync(cancellationToken);
            if (saveResult <= 0)
            {
                _logger.LogError("CreateAccountCommand: Failed to create account {@Cmd}.", cmd);
                return new AccountDTO(); // TODO: return error code: Failed to create account
            }
            else
            {
                _logger.LogInformation("CreateAccountCommand: Account created successfully {@Cmd}.", cmd);
            }
            return newAccount.Adapt<AccountDTO>();
           
        }
    }

    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator(ILogger<CreateAccountCommandValidator> logger)
        {
            RuleFor(command => command.AccountRequest.AccountNumber).NotEmpty();
            RuleFor(command => command.AccountRequest.Currency).NotEmpty();
            logger.LogTrace("Validator created - {@Name}", GetType().Name);
        }
    }
}
