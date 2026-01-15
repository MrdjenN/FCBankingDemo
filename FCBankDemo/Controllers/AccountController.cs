using FCBankDemo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCBankDemo.Controllers
{
    [ApiController]
    [Route("Accounts")]
    public class AccountController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<bool> CreateAccount()
        {
            return await Task.FromResult(true);
        }

    }
}
