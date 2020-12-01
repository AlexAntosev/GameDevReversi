using System.Collections.Generic;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface IBoardService
    {
        Dictionary<string, Disk> CreateBoard();

        void PrepareBoardToPlay(Dictionary<string, Disk> board);
    }
}