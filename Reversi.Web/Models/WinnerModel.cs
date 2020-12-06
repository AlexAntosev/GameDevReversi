using Reversi.Business.Contracts.Models;

namespace Reversi.Web.Models
{
    public class WinnerModel
    {
        public Player Winner { get; set; }

        public bool IsWinnerPresent => Winner != null;
    }
}