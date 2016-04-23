using System;

namespace STG.DataAccess.DataModels
{
    public class GamePlay
    {
        public int GameId { get; set; }
        public DateTime EndedAt { get; set; }
        public Set[] Sets { get; set; }
    }
}
