using System;

namespace ScoreToGo.Models
{
    public class GameModel
    {
        public GameModel()
        {
            Teams = new TeamModel[2];
        }

        public int Id { get; set; }

        public TeamModel[] Teams { get; set; }

        public DateTime StartedAt { get; set; }

        public GamePlayModel GamePlay { get; set; }
    }
}