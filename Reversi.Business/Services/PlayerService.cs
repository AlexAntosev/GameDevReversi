using System;
using System.Collections.Generic;
using Reversi.Business.Contracts.Constants;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class PlayerService : IPlayerService
    {
        public Player CreatePlayer(string name, Side side)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Disks = PreparePlayerDisks(side),
                Side = side
            };
            
            return player;
        }

        private List<Disk> PreparePlayerDisks(Side side)
        {
            var disks = new List<Disk>();
            for (int i = 0; i < InitialSessionSettings.PlayerDisksCount; i++)
            {
                disks.Add(new Disk(side));
            }

            return disks;
        }
    }
}