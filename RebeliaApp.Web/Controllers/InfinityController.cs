using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RebeliaApp.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebeliaApp.Web.Controllers
{
    [Route("Api/InfinityEndpoint")]
    [ApiController]
    public class InfinityController : ControllerBase
    {
        IInfinityService infinityService;
        
        public InfinityController(IInfinityService _infinityService) {
            infinityService = _infinityService;
        }

        [HttpGet("GetInfinityArmies")]
        [Authorize]
        public async Task<IActionResult> GetInfinityArmies()
        {
            return Ok(await infinityService.GetInfinityArmies());
        }

        [HttpGet("GetInfinityScenarios")]
        [Authorize]
        public async Task<IActionResult> GetInfinityScenarios()
        {
            return Ok(await infinityService.GetInfinityScenarios());
        }



    }
}
