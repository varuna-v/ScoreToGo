using System;

namespace STG.Domain.Models
{
    public class GamePlay
    {
        public Guid GameId { get; set; }
        public Set[] Sets { get; set; }
        public int[] SetWins { get; set; }
        private int _currentSetNumber = -1;
        public int CurrentSetNumber
        {
            get
            {
                if (SetWins != null)
                    _currentSetNumber = SetWins[0] + SetWins[1];
                return _currentSetNumber;
            }
        }
        public bool GameOver { get; set; }
        public int CurrentServer { get; set; }
    }
}
