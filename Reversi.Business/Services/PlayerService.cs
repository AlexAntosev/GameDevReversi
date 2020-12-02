using System;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class PlayerService : IPlayerService
    {
        public Player CreatePlayer(Color color)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Color = color
            };
            
            return player;
        }
    }
}