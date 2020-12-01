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
        
        public Session CreateSession(Player player)
        {
            var session = new Session()
            {
                Board = _boardService.CreateBoard(),
                Player = player,
                Opponent = _playerService.CreatePlayer("Bot", Side.Dark),
                Turn = Side.Dark
            };
            
            _boardService.PrepareBoardToPlay(session.Board);

            return session;
        }

        public Session MakeTurn(Session session, string boardPlace)
        {
            var currentPlayer = session.Turn == Side.Light ? session.Player : session.Opponent;
            currentPlayer = _playerService.SpendDisk(currentPlayer);

            _boardService.PlaceDisk(session.Board, boardPlace, currentPlayer.Side);
            
            session.Turn = SwitchTurn(session.Turn);
            return session;
        }

        private Side SwitchTurn(Side currentSide)
        {
            currentSide = currentSide == Side.Light ? Side.Dark : Side.Light;

            return currentSide;
        }
    }
}