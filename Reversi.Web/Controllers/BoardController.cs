using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;
using Reversi.Web.Models;

namespace Reversi.Web.Controllers
{
    [Route("api/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        [Route("make-turn")]
        public void MakeTurn([FromBody]MakeTurnModel makeTurnModel)
        {
            var position = new Position(makeTurnModel.Cell);
            _boardService.MakeTurn(makeTurnModel.PlayerId, position);
        }

        [HttpGet]
        [Route("possible-moves/{playerId}")]
        public List<Position> GetPossibleMoves(Guid playerId)
        {
            var possibleMoves = _boardService.GetPossibleMovesForPlayer(playerId);

            return possibleMoves;
        }
        
        [HttpGet]
        public Board GetBoard()
        {
            var board = _boardService.GetBoard();

            return board;
        }
    }
}