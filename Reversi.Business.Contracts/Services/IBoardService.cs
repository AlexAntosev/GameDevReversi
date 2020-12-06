using System;
using System.Collections.Generic;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface IBoardService
    {
        public void MakeTurn(Guid playerId, Position position);
        
        List<Position> GetPossibleMovesForPlayer(Guid playerId);

        Board GetBoard();

        Player CheckWinner();
    }
}