namespace Reversi.Business.Contracts.Models
{
    public class Cell
    {
        public bool IsEmpty => Disk == null;

        public Disk Disk { get; set; }
    }
}