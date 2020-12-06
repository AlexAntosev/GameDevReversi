using System;
using Reversi.Business.Contracts.Enums;

namespace Reversi.Business.Contracts.Models
{
    public class Player
    {
        public Player(Color color)
        {
            Id = Guid.NewGuid();
            Color = color;
        }
        
        public Guid Id { get; }
        
        public Color Color { get; }
    }
}