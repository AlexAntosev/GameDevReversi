using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class SessionService : ISessionService
    {
        private readonly Session _session;

        private readonly IPlayerService _playerService;
        private readonly IBoardService _boardService;

        public SessionService(IPlayerService playerService, IBoardService boardService)
        {
            _playerService = playerService;
            _boardService = boardService;
            _session = CreateSession();
        }

        public Session CreateSession()
        {
            var session = new Session()
            {
                Board = new Board(),
                Players = new List<Player>()
                {
                    _playerService.CreatePlayer(Color.Light),
                    _playerService.CreatePlayer(Color.Dark)
                },
                Turn = Color.Dark
            };

            return session;
        }

        public void MakeTurn(Guid playerId, Position position)
        {
            var currentPlayer = _session.Players.FirstOrDefault(p => p.Id == playerId);
            if (currentPlayer == null)
            {
                throw new Exception($"Player {playerId} not found");
            }

            _boardService.PlaceDisk(_session.Board, position, currentPlayer.Color);
            _session.Turn = SwitchTurn(_session.Turn);
        }

        public List<Position> GetPossibleMoves(Guid playerId)
        {
            var currentPlayer = _session.Players.FirstOrDefault(p => p.Id == playerId);
            if (currentPlayer == null)
            {
                throw new Exception($"Player {playerId} not found");
            }

            var possibleMoves = _boardService.GetPossibleMoves(_session.Board, currentPlayer.Color);

            return possibleMoves;
        }

        public List<Player> GetPlayers()
        {
            var players = _session.Players;

            return players;
        }

        public Board GetBoard()
        {
            var board = _session.Board;

            return board;
        }

        private Color SwitchTurn(Color currentColor)
        {
            currentColor = currentColor == Color.Light ? Color.Dark : Color.Light;

            return currentColor;
        }
    }
}