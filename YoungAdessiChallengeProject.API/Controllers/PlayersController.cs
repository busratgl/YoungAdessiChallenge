using Microsoft.AspNetCore.Mvc;
using YoungAdessiChallengeProject.Business.Abstract;

namespace YoungAdessiChallengeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Get Winner Player
        /// </summary>
        [HttpGet("winner")]
        public int GetWinner([FromQuery] int count)
        {
            var players = _playerService.GetWinnerPlayer(count);
            return players;
        }
    }
}