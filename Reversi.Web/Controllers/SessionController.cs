using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;
using Reversi.Web.Models;

namespace Reversi.Web.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        [Route("make-turn")]
        public void MakeTurn([FromBody]MakeTurnModel makeTurnModel)
        {
            var position = new Position(makeTurnModel.Cell);
            _sessionService.MakeTurn(makeTurnModel.PlayerId, position);
        }

        [HttpGet]
        [Route("possible-moves/{playerId}")]
        public List<Position> GetPossibleMoves(Guid playerId)
        {
            var possibleMoves = _sessionService.GetPossibleMoves(playerId);

            return possibleMoves;
        }
        
        [HttpGet]
        [Route("players")]
        public List<Player> GetPlayers()
        {
            var players = _sessionService.GetPlayers();

            return players;
        }
        
        [HttpGet]
        [Route("board")]
        public Board GetBoard()
        {
            var board = _sessionService.GetBoard();

            return board;
        }
    }
}