using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Disk
    {
        public Side Side { get; }

        public Disk(Side side)
        {
            Side = side;
        }
    }
}