using System.Collections.Generic;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface ISessionService
    {
        void CreateNewSession(Player player, Player opponent);

        List<Player> GetPlayers();
        
        Board GetBoard();
    }
}