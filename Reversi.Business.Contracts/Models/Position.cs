using Reversi.Business.Contracts.Parsers;

namespace Reversi.Business.Contracts.Models
{
    public class Position
    {
        public char Row { get; set; }
        
        public char Column { get; set; }

        public Position(char row, char column)
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
        
        public string NextColumn()
        {
            var newColumn = Column;
            return new Position(Row, ++newColumn).ToString();
        }
        
        public static bool operator ==(Position x, Position y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Position x, Position y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || GetType() != obj.GetType())
            {
                return false;
            }

            var position = (Position) obj;

            return Row == position.Row && Column == position.Column;
        }
        
        public override int GetHashCode()
        {
            return (Row, Column).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Row}{Column}";
        }
    }
}