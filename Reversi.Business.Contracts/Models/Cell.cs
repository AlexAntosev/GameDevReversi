namespace Reversi.Business.Contracts.Models
{
    public class Cell
    {
        public Position Position { get; set; }

        public bool IsEmpty => Disk == null;

        public Disk Disk { get; set; }

        public Cell(Position position)
        {
            Position = position;
        }
    }
}