using System.Collections.Generic;
using System.Linq;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;
using Reversi.Business.Extensions;

namespace Reversi.Business.Services
{
    public class BoardService : IBoardService
    {
        public List<string> GetPossibleMoves(Board board, Color color)
        {
            var playerDisksPositions = board.Cells
                .Where(c => !c.Value.IsEmpty && c.Value.Disk.Color == color.OpponentColor())
                .Select(c => c.Key)
                .ToList();
            
            var possibleMoves = new List<string>();
            foreach (var playerDisksPosition in playerDisksPositions)
            {
                var adjacentEmptyPosition = FindAdjacentEmptyPosition(board, playerDisksPosition);
                possibleMoves.AddRange(adjacentEmptyPosition);
            }

            var uniqPossibleMoves = possibleMoves.Distinct().ToList();
            
            return uniqPossibleMoves;
        }

        private List<string> FindAdjacentEmptyPosition(Board board, Position position)
        {
            var possiblePositions = board.Cells
                .Where(c => c.Value.IsEmpty)
                .Where(c => c.Key.ToString() == position.NextColumn() ||
                                   c.Key.ToString() == position.PreviousColumn() ||
                                   c.Key.ToString() == position.NextRow() ||
                                   c.Key.ToString() == position.PreviousRow())
                .Select(c => c.Key.ToString())
                .ToList();

            return possiblePositions;
        }
    }
}