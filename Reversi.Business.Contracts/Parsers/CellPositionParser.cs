using System;
using System.Collections.Generic;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Parsers
{
    public static class CellPositionParser
    {
        public static Position Parse(string cell)
        {
            var parseResult = TryParse(cell, out Position position);
            if (parseResult == false)
            {
                throw new Exception("Invalid parse cell position");
            }

            return position;
        }
        
        public static bool TryParse(string cell, out Position position)
        {
            position = null;
            
            if (cell.Length != 2)
            {
                return false;
            }

            var column = cell[0];
            if (!PossibleColumns.Contains(column))
            {
                return false;
            }
            
            var row = cell[1];
            if (!PossibleRows.Contains(row))
            {
                return false;
            }
            
            position = new Position(column, row);

            return true;
        }
        
        private static List<char> PossibleColumns = new List<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'
        };
        
        private static List<char> PossibleRows = new List<char>()
        {
            '1', '2', '3', '4', '5', '6', '7', '8'
        };
    }
}