using System;

namespace STG.Domain.Models
{
    public class Game : ModelBase
    {
        public Team[] Teams { get; set; }
        public GamePlay GamePlay { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        public override string IdPrefix
        {
            get
            {
                return "game";
            }
        }
    }
}
