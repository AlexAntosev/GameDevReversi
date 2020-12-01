using System.Collections.Generic;
using Reversi.Business.Contracts.Constants;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class SessionService : ISessionService
    {
        private readonly IPlayerService _playerService;

        public SessionService(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public Session CreateSession()
        {
            var session = new Session()
            {
                Board = CreateBoard(),
                Player = _playerService.CreatePlayer("You", Side.Light),
                Opponent = _playerService.CreatePlayer("Bot", Side.Dark),
                Turn = Side.Dark
            };

            return session;
        }

        private Dictionary<string, Disk> CreateBoard()
        {
            var board = new Dictionary<string, Disk>();
            
            var row = 'A';
            var column = 1;
            for (int i = 0; i < InitialSessionSettings.BoardRowDisksCount; i++)
            {
                for (int j = 0; j < InitialSessionSettings.BoardColumnDisksCount; j++)
                {
                    var boardPlace = $"{row}{column}";
                    board.Add(boardPlace, null);

                    row++;
                    column++;
                }
            }

            return board;
        }
    }
}