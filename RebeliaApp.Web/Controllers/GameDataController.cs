using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RebeliaApp.Web.Model;
using RebeliaApp.Web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RebeliaApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameDataController : ControllerBase
    {
        IGameDataService gameDataService;

        public GameDataController(IGameDataService _gameDataService) {
            gameDataService = _gameDataService;
        }

        [HttpGet("GetInfinityArmies")]
        public async Task<IActionResult> GetInfinityArmies() {
            return Ok(await gameDataService.GetInfinityArmies());
        }

        [HttpGet("GetWarmachineArmies")]
        public async Task<IActionResult> GetWarmachineHordesArmies()
        {
            return Ok(await gameDataService.GetWarmachineHordesArmies());
        }

        [HttpGet("GetAllGameSystems")]
        public async Task<IActionResult> GetAllGameSystems()
        {
            return Ok(await gameDataService.GetAllGameSystems());
        }

        [HttpPost("AddInfinityMissions")]
        public async Task<IActionResult> AddInfinityMissions()
        {
            return Ok(await gameDataService.AddInfinityMissions());
        }
        [HttpPost("AddInfinityThemes")]
        public async Task<IActionResult> AddInfinityThemes()
        {
            return Ok(await gameDataService.AddInfinityThemes());
        }
        [HttpPost("AddInfinityArmies")]
        public async Task<IActionResult> AddInfinityArmies()
        {
            return Ok(await gameDataService.AddInfinityArmies());
        }
        [HttpGet("GetInfinityScenarios")]
        public async Task<IActionResult> GetInfinityScenarios() {
            return Ok(await gameDataService.GetInfinityScenarios());
        }
        [HttpPost("AddInfinityMapFormats")]
        public async Task<IActionResult> AddInfinityMapFormats() {
            return Ok(await gameDataService.AddInfinityMapFormats());
        }

    }


}
