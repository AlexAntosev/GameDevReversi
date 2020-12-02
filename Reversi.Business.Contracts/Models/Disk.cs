using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Disk
    {
        public Color Color { get; set; }

        public Disk(Color color)
        {
            Color = color;
        }
    }
}