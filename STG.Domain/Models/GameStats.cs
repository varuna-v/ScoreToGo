using System;

namespace STG.Domain.Models
{
    public class GameStats
    {
        public Guid GameId { get; set; }
        public int Winner { get; set; }
        public TeamInGameStats[] TeamInGameStats { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
