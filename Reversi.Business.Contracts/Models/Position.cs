﻿using Reversi.Business.Contracts.Parsers;

namespace Reversi.Business.Contracts.Models
{
    public class Position
    {
        public char Row { get; }

        public char Column { get; }

        public Position(char column, char row)
        {
            Row = row;
            Column = column;
        }
        
        public Position(string cell)
        {
            var position = CellPositionParser.Parse(cell);
            
            Row = position.Row;
            Column = position.Column;
        }
        
        public Position Move(int row, int column)
        {
            var newColumn = Column + column;
            var newRow = Row + row;
            
            return new Position((char)newColumn, (char)newRow);
        }
        
        public static bool operator ==(Position x, Position y)
        {
            return x?.Equals(y) ?? ReferenceEquals(y, null);
        }

        public static bool operator !=(Position x, Position y)
        {
            return !(x ==y);
        }

        public override bool Equals(object obj)
        {
            return obj is Position position  && Row == position.Row && Column == position.Column;
        }
        
        public override int GetHashCode()
        {
            return (Row, Column).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}