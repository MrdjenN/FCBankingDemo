using FCBankDemo.Commands;
using FCBankDemo.Common;
using FCBankDemo.DTO;
using FCBankDemo.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCBankDemo.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult<AccountDTO>> CreateAccount(CreateAccountDTO account)
        {
            var result = await _mediator.Send(new CreateAccountCommand(account));
            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Data);
        }

        [HttpPost("Deposit")]
        public async Task<ActionResult<AccountDTO>> Deposit(DepositAccountDTO account)
        {
            var result = await _mediator.Send(new DepositAccountCommand(account));
            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Data);
        }

        [HttpPost("Withdraw")]
        public async Task<ActionResult<AccountDTO>> Withdraw(WithdrawAccountDTO account)
        {
            var result = await _mediator.Send(new WithdrawAccountCommand(account));
            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Data);
        }

        [HttpPost("Transfer")]
        public async Task<ActionResult<bool>> Transfer(TransferAccountDTO account)
        {
            var result = await _mediator.Send(new TransferAccountCommand(account));
            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Data);
        }

        [HttpPost("Balance")]
        public async Task<ActionResult<decimal>> Balance(string accountNumber)
        {
            var result = await _mediator.Send(new GetAccountBallanceCommand(accountNumber));
            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(result.Data);
        }
    }
}
