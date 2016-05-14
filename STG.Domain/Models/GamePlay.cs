using System;

namespace STG.Domain.Models
{
    public class GamePlay
    {
        public int GameId { get; set; }
        public DateTime EndedAt { get; set; } //!!Move to game model
        public Set[] Sets { get; set; }
        public int[] SetWins { get; set; }
    }
}
