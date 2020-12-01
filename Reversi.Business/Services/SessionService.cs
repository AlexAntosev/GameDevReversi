using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class SessionService : ISessionService
    {
        private readonly IPlayerService _playerService;
        private readonly IBoardService _boardService;

        public SessionService(IPlayerService playerService, IBoardService boardService)
        {
            _playerService = playerService;
            _boardService = boardService;
        }
        
        public Session CreateSession()
        {
            var session = new Session()
            {
                Board = _boardService.CreateBoard(),
                Player = _playerService.CreatePlayer("You", Side.Light),
                Opponent = _playerService.CreatePlayer("Bot", Side.Dark),
                Turn = Side.Dark
            };
            
            _boardService.PrepareBoardToPlay(session.Board);

            return session;
        }
    }
}