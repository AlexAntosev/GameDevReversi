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
                var adjacentEmptyPosition = FindPossiblePosition(board, playerDisksPosition, color);
                possibleMoves.AddRange(adjacentEmptyPosition);
            }

            var uniqPossibleMoves = possibleMoves.Distinct().ToList();
            
            return uniqPossibleMoves;
        }

        public void PlaceDisk(Board board, Position position, Color color)
        {
            board.PlaceDisk(position, color);
            var possibleVectors = GetPossibleVectors();
            
            foreach (var possibleVector in possibleVectors)
            {
                CheckPositionForSwitch(possibleVector, position, board, color);
            }
        }

        private List<string> FindPossiblePosition(Board board, Position position, Color color)
        {
            var possibleVectors = GetPossibleVectors();
            var possiblePositions = new List<string>();
            
            foreach (var possibleVector in possibleVectors)
            {
                var possiblePosition = CheckPositionForMove(possibleVector, position, board, color);
                if (possiblePosition != null)
                {
                    possiblePositions.Add(possiblePosition.ToString());
                }
            }

            return possiblePositions;
        }

        private Position CheckPositionForMove(
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
                return CheckPositionForMove(vector, adjacentPosition, board, color);
            }

            if (adjacentCell.IsEmpty && currentCell != null && currentCell.Disk.Color != color)
            {
                return adjacentPosition;
            }

            return null;
        }
        
        private bool CheckPositionForSwitch(
            (int row, int column) vector,
            Position position,
            Board board,
            Color color)
        {
            var adjacentPosition = position.Change(vector.row, vector.column);
            var adjacentCell = board.Cells
                .FirstOrDefault(c => c.Key.ToString() == adjacentPosition.ToString()).Value;

            if (adjacentCell == null)
            {
                return false;
            }
            
            if (!adjacentCell.IsEmpty && adjacentCell.Disk.Color == color.OpponentColor())
            {
                if (CheckPositionForSwitch(vector, adjacentPosition, board, color))
                {
                    adjacentCell.Disk.Color = adjacentCell.Disk.Color.OpponentColor();
                }
            }

            if (!adjacentCell.IsEmpty && adjacentCell.Disk.Color == color)
            {
                return true;
            }

            return false;
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