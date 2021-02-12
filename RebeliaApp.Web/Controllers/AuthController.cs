using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RebeliaApp.Web.Dto.AuthService.Request;
using RebeliaApp.Web.Services;


namespace RebeliaApp.Web.Controllers
{
    [ApiController]
    [Route("Api/[controller]Endpoint")]
    public class AuthController : ControllerBase
    {
        public IAuthService authService { get; set; }

        public AuthController(IAuthService _authService) {
            authService = _authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest request) {
            return Ok(await authService.Login(request));
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
