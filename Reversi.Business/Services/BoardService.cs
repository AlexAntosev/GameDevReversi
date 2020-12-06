using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Business.Contracts.Constants;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;
using Reversi.Business.Extensions;

namespace Reversi.Business.Services
{
    public class BoardService : IBoardService
    {
        private readonly ISessionService _sessionService;

        public BoardService(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        
        public void MakeTurn(Guid playerId, Position position)
        {
            var currentPlayer = GetCurrentPlayer(playerId);
            var board = GetBoard();
            
            PlaceDisk(board, position, currentPlayer.Color);
        }

        public List<Position> GetPossibleMovesForPlayer(Guid playerId)
        {
            var currentPlayer = GetCurrentPlayer(playerId);
            var board = GetBoard();
            var possibleMoves = GetPossibleMoves(board, currentPlayer.Color);

            return possibleMoves;
        }
        
        public Board GetBoard()
        {
            var board = _sessionService.GetBoard();

            return board;
        }

        private Player GetCurrentPlayer(Guid playerId)
        {
            var currentPlayer = _sessionService.GetPlayers().FirstOrDefault(p => p.Id == playerId);
            if (currentPlayer == null)
            {
                throw new Exception($"Player {playerId} not found");
            }

            return currentPlayer;
        }

        private List<Position> GetPossibleMoves(Board board, Color color)
        {
            var playerDisksPositions = board.Cells
                .Where(c => !c.IsEmpty && c.Disk.Color == color)
                .Select(c => c.Position)
                .ToList();
            
            var possibleMoves = new List<Position>();
            foreach (var playerDisksPosition in playerDisksPositions)
            {
                var adjacentEmptyPosition = FindPossiblePositions(board, playerDisksPosition, color);
                possibleMoves.AddRange(adjacentEmptyPosition);
            }

            var uniqPossibleMoves = possibleMoves.Distinct().ToList();
            
            return uniqPossibleMoves;
        }

        private void PlaceDisk(Board board, Position position, Color color)
        {
            TryPlaceDisk(board, position, color);
            SwitchOpponentDisks(board, position, color);
        }

        private void SwitchOpponentDisks(Board board, Position position, Color color)
        {
            var basisVectors = Vectors.GetBasis();

            foreach (var vector in basisVectors)
            {
                TrySwitchDisk(vector, position, board, color);
            }
        }

        private void TryPlaceDisk(Board board, Position position, Color color)
        {
            var possiblePositions = GetPossibleMoves(board, color);
            if (possiblePositions.Contains(position))
            {
                board.PlaceDisk(position, color);
            }
            else
            {
                throw new Exception("Not possible to place disk");
            }
        }

        private List<Position> FindPossiblePositions(Board board, Position position, Color color)
        {
            var basisVectors = Vectors.GetBasis();
            var possiblePositions = new List<Position>();
            
            foreach (var vector in basisVectors)
            {
                var possiblePosition = CheckPositionForMove(vector, position, board, color);
                if (possiblePosition != null)
                {
                    possiblePositions.Add(possiblePosition);
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
            var adjacentPosition = position.Move(vector.row, vector.column);
            var adjacentCell = board.Cells
                .FirstOrDefault(c => c.Position.ToString() == adjacentPosition.ToString());
            var currentCell = board.Cells
                .FirstOrDefault(c => c.Position.ToString() == position.ToString());

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
        
        private bool TrySwitchDisk(
            (int y, int x) vector,
            Position position,
            Board board,
            Color currentPlayerColor)
        {
            var adjacentPosition = position.Move(vector.y, vector.x);
            var adjacentCell = board.Cells
                .FirstOrDefault(c => c.Position.ToString() == adjacentPosition.ToString());

            if (adjacentCell == null)
            {
                return false;
            }
            
            if (IsOpponentDisk(currentPlayerColor, adjacentCell))
            {
                if (TrySwitchDisk(vector, adjacentPosition, board, currentPlayerColor))
                {
                    adjacentCell.Disk.Color = adjacentCell.Disk.Color.OpponentColor();
                }
            }

            if (IsPlayerDisk(currentPlayerColor, adjacentCell))
            {
                return true;
            }

            return false;
        }

        private static bool IsPlayerDisk(Color currentPlayerColor, Cell adjacentCell)
        {
            return !adjacentCell.IsEmpty && adjacentCell.Disk.Color == currentPlayerColor;
        }

        private static bool IsOpponentDisk(Color color, Cell adjacentCell)
        {
            return !adjacentCell.IsEmpty && adjacentCell.Disk.Color == color.OpponentColor();
        }
    }
}