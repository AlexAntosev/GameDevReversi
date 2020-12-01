using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Session
    {
        public Player Player { get; set; }
        
        public Player Opponent { get; set; } 
            
        public Dictionary<string, Disk> Board { get; set; }
        
        public Side Turn { get; set; }
    }
}