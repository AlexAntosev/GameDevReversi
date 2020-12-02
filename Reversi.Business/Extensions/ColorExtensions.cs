using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Extensions
{
    public static class ColorExtensions
    {
        public static Color OpponentColor(this Color color)
        {
            return color == Color.Light ? Color.Dark : Color.Light;
        }
    }
}