using Reversi.Business.Contracts.Models;

namespace Reversi.Business.Contracts.Services
{
    public interface ISessionService
    {
        public Session CreateSession();
    }
}