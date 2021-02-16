using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RebeliaApp.Web.Dto.Shared;
using RebeliaApp.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebeliaApp.Web.Controllers
{
    [Route("Api/WarmachineEndpoint")]
    [ApiController]
    public class WarmachineController : ControllerBase
    {
        IWarmachineService warmachineService;


        public WarmachineController(IWarmachineService _warmachineService)
        {
            warmachineService = _warmachineService;
        }

        [HttpGet("GetWarmachineArmies")]
        [Authorize]
        public async Task<IActionResult> GetWarmachineArmies() {
            return Ok(await warmachineService.GetArmies());
        }

        [HttpGet("GetWarmachineScenarios")]
        [Authorize]
        public async Task<IActionResult> GetWarmachineScenarios()
        {
            return Ok(await warmachineService.GetScenarios());
        }

        [HttpPost("SubmitFriendlyGameResult")]
        [Authorize]
        public async Task<IActionResult> SubmitFriendlyGameResult(FriendlyGameResultRequest request)
        {
            return Ok(await warmachineService.SubmitFriendlyGameResult(request));
        }



    }
}
