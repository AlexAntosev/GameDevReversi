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
                .Where(c => !c.Value.IsEmpty && c.Value.Disk.Color == color)
                .Select(c => c.Key)
                .ToList();
            
            var possibleMoves = new List<string>();
            foreach (var playerDisksPosition in playerDisksPositions)
            {
                var adjacentEmptyPosition = FindAdjacentEmptyPosition(board, playerDisksPosition, color);
                possibleMoves.AddRange(adjacentEmptyPosition);
            }

            var uniqPossibleMoves = possibleMoves.Distinct().ToList();
            
            return uniqPossibleMoves;
        }

        private List<string> FindAdjacentEmptyPosition(Board board, Position position, Color color)
        {
            var possibleVectors = GetPossibleVectors();
            var possiblePositions = new List<string>();
            
            foreach (var possibleVector in possibleVectors)
            {
                var possiblePosition = CheckPosition(possibleVector, position, board, color);
                if (possiblePosition != null)
                {
                    possiblePositions.Add(possiblePosition.ToString());
                }
            }

            return possiblePositions;
        }

        private Position CheckPosition(
            (int row, int column) vector,
            Position position,
            Board board,
            Color color)
        {
            var adjacentPosition = position.Change(vector.row, vector.column);
            var adjacentCell = board.Cells
                .FirstOrDefault(c => c.Key.ToString() == adjacentPosition.ToString()).Value;
            var currentCell = board.Cells
                .FirstOrDefault(c => c.Key.ToString() == position.ToString()).Value;

            if (adjacentCell == null || (!adjacentCell.IsEmpty && adjacentCell.Disk.Color == color))
            {
                return null;
            }

            if (!adjacentCell.IsEmpty && adjacentCell.Disk.Color == color.OpponentColor())
            {
                return CheckPosition(vector, adjacentPosition, board, color);
            }

            if (adjacentCell.IsEmpty && currentCell != null && currentCell.Disk.Color != color)
            {
                return adjacentPosition;
            }

            return null;
        }

        private List<(int row, int column)> GetPossibleVectors()
        {
            var vectors = new List<(int, int)>()
            {
                (-1, 0),
                (-1, 1),
                (0, 1),
                (1, 1),
                (1, 0),
                (1, -1),
                (0, -1),
                (-1, -1)
            };

            return vectors;
        }
    }
}