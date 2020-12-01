using Microsoft.AspNetCore.Mvc;
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
        [Route("create")]
        public Session CreateSession(Player player)
        {
            var session = _sessionService.CreateSession(player);
            
            return session;
        }

        [HttpPost]
        [Route("make-turn")]
        public Session MakeTurn(Session session, string boardPlace)
        {
            session = _sessionService.MakeTurn(session, boardPlace);

            return session;
        }
    }
}