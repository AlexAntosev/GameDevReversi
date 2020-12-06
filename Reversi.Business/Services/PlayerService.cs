using System;
using System.Collections.Generic;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ISessionService _sessionService;

        public PlayerService(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        
        public List<Player> GetPlayers()
        {
            var players = _sessionService.GetPlayers();

            return players;
        }
    }
}