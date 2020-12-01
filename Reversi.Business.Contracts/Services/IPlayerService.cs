using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface IPlayerService
    {
        Player CreatePlayer(string name, Side side);

        Player SpendDisk(Player player);
    }
}