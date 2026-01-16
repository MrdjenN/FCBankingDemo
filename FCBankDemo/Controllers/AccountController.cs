using FCBankDemo.Commands;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCBankDemo.Controllers
{
    [ApiController]
    [Route("Accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Create")]
        public async Task<AccountDTO> CreateAccount(CreateAccountDTO account)
        {
            return await _mediator.Send(new CreateAccountCommand(account));
        }

        [HttpPost("Deposit")]
        public async Task<AccountDTO> Deposit(DepositAccountDTO account)
        {
            return await _mediator.Send(new DepositAccountCommand(account));
        }

        [HttpPost("Withdraw")]
        public async Task<AccountDTO> Withdraw(WithdrawAccountDTO account)
        {
            return await _mediator.Send(new WithdrawAccountCommand(account));
        }

        [HttpPost("Transfer")]
        public async Task<bool> Transfer(TransferAccountDTO account)
        {
            return await _mediator.Send(new TransferAccountCommand(account));
        }

        [HttpPost("Balance")]
        public async Task<decimal> Balance(string accountNumber)
        {
            return await _mediator.Send(new GetAccountBallanceCommand(accountNumber));
        }

    }
}
