using System;

namespace Reversi.Web.Models
{
    public class MakeTurnModel
    {
        public Guid PlayerId { get; set; }
        
        public string Cell { get; set; }
    }
}