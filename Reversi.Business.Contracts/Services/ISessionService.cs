﻿using System;
using System.Collections.Generic;
using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface ISessionService
    {
        public Session CreateSession();

        public void MakeTurn(Guid playerId, Position position);
        
        List<string> GetPossibleMoves(Guid playerId);
        
        List<Player> GetPlayers();
    }
}