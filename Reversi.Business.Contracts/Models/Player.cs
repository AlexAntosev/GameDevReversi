using System;
using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Disk> Disks { get; set; }
        
        public Side Side { get; set; }
    }
}