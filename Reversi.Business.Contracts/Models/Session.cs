using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Session
    {
        public List<Player> Players { get; set; }
            
        public Board Board { get; set; }
        
        public Color Turn { get; set; }
    }
}