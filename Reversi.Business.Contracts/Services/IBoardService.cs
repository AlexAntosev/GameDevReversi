using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface IBoardService
    {
        List<string> GetPossibleMoves(Board board, Color color);

        void PlaceDisk(Board board, Position position, Color color);
    }
}