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

    }
}
