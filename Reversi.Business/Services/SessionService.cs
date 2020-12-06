using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class SessionService : ISessionService
    {
        private Session Session { get; set; }

        public SessionService()
        {
            CreateNewSession(new Player(Color.Light), new Player(Color.Dark));
        }

        public void CreateNewSession(Player player, Player opponent)
        {
            var session = new Session()
            {
                Board = new Board(),
                Players = new List<Player>()
                {
                    player,
                    opponent
                }
            };

            Session = session;
        }

        public List<Player> GetPlayers()
        {
            return Session.Players;
        }
        
        public Board GetBoard()
        {
            return Session.Board;
        }
    }
}