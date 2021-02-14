using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RebeliaApp.Web.Dto.AccountService.Request;
using RebeliaApp.Web.Model;
using RebeliaApp.Web.Services;

namespace RebeliaApp.Web.Controllers
{
    [ApiController]
    [Route("Api/AccountEndpoint")]
    public class AccountController : ControllerBase
    {
        IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpGet("GetAllAccounts")]
        [Authorize]
        public async Task<IActionResult> GetAllAccounts() {
            return Ok(await accountService.GetAllAccounts());
        }

        [HttpGet("GetAccountById/{_id}")]
        [Authorize]
        public async Task<IActionResult> GetAccountById(int _id)
        {
            return Ok(await accountService.GetAccountById(_id));
        }

        [HttpGet("GetAllAccountsExceptLoggedUser/{_id}")]
        [Authorize]
        public async Task<IActionResult> GetAllAccountsExceptLoggedUser(int _id)
        {
            return Ok(await accountService.GetAllAccountsExceptLoggedUser(_id));
        }




    }
}
