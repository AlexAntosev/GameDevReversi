using System;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        
        public Color Color { get; set; }
    }
}