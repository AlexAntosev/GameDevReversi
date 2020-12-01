using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Session
    {
        public Dictionary<string, Disk> Board { get; set; }
        
        public Side Turn { get; set; }
    }
}