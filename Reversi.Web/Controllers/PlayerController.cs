using Microsoft.AspNetCore.Mvc;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Web.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        [Route("create")]
        public Player CreateSession(string name)
        {
            var player = _playerService.CreatePlayer(name, Side.Light);
            
            return player;
        }
    }
}