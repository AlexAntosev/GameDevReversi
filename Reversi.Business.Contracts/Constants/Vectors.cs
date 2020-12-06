using System.Collections.Generic;

namespace Reversi.Business.Contracts.Constants
{
    public static class Vectors
    {
        public static List<(int row, int column)> GetBasis()
        {
            var vectors = new List<(int, int)>()
            {
                (-1, 0),
                (-1, 1),
                (0, 1),
                (1, 1),
                (1, 0),
                (1, -1),
                (0, -1),
                (-1, -1)
            };

            return vectors;
        }
    }
}