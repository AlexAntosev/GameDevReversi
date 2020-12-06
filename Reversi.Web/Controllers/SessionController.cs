using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reversi.Business.Contracts.Enums;
using Reversi.Business.Contracts.Models;
using Reversi.Business.Contracts.Services;

namespace Reversi.Web.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        
        [HttpPost]
        public void CreateNew()
        {
            _sessionService.CreateNewSession(new Player(Color.Light), new Player(Color.Dark));
        }
    }
}