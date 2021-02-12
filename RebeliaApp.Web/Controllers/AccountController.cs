using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Model;
using RebeliaApp.Web.Services;

namespace RebeliaApp.Web.Controllers
{
    [ApiController]
    [Route("Api/[controller]Endpoint")]
    public class AccountController : ControllerBase
    {
        IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts() {
            return Ok(await accountService.GetAllAccounts());
        }

        [HttpGet("GetAccountById/{_id}")]
        public async Task<IActionResult> GetAccountById(int _id)
        {
            return Ok(await accountService.GetAccountById(_id));
        }

        [HttpPost("LoginToUserAccount")]
        public async Task<IActionResult> LoginToUserAccount(LogInUserRequest request)
        {
            return Ok(await accountService.LoginToUserAccount(request));
        }


    }
}
