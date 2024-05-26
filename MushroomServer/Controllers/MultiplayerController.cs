using Microsoft.AspNetCore.Mvc;
using MushroomServer.Models;
using MushroomServer.Services;

namespace MushroomServer.Controllers
{
    [ApiController]
    public class MultiplayerController : Controller
    {
        private AccountService accountService = AccountService.Instance;

        [HttpGet("/api")]
        public ActionResult<string> Index()
        {
            return "Online";
        }

        [HttpPost("/api/login")]
        public IActionResult PostLogin([FromBody] AccountRequest accountRequest)
        {
            string connectId = accountService.Login(accountRequest.Username, accountRequest.Password);

            if (string.IsNullOrEmpty(connectId))
            {
                return BadRequest("Invalid username or password! You could also be logged in already!");
            }
            return Ok(connectId);
        }

        [HttpPost("/api/register")]
        public IActionResult PostRegister([FromBody] AccountRequest accountRequest)
        {
            bool success = accountService.Register(accountRequest.Username, accountRequest.Password);

            if (!success)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        public class AccountRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }
    }
}