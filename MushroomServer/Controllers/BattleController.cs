using Microsoft.AspNetCore.Mvc;
using MushroomServer.Models;
using MushroomServer.Services;

namespace MushroomServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : Controller
    {
        private MultiplayerService multiplayerService = MultiplayerService.Instance;

        [HttpGet]
        public ActionResult<string> Index()
        {
            return "Online";
        }

        [HttpPost("join")]
        public IActionResult Post([FromBody] JoinRequest joinRequest)
        {
            Character character = new Character(joinRequest.Name, joinRequest.HP, joinRequest.EXP, joinRequest.Skill);
            Player player = new Player { GUID = joinRequest.GUID, Character = character };

            string? resultId = multiplayerService.JoinPlayer(player);
            if (string.IsNullOrEmpty(resultId))
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Ok(resultId);
        }

        [HttpGet("result/{resultId}")]
        public IActionResult Get(string resultId)
        {
            Result result = multiplayerService.GetResult(resultId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        public class JoinRequest
        {
            public required string GUID { get; set; }
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int HP { get; set; }
            public required int EXP { get; set; }
            public required string Skill { get; set; }
        }
    }
}