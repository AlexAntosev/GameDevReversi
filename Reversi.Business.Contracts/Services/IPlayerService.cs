using System.Collections.Generic;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();
    }
}