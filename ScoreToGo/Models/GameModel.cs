namespace ScoreToGo.Models
{
    public class GameModel
    {
        public SetModel[] Sets { get; set; }

        public int[] SetWins { get; set; }

        private int _currentSetNumber = -1;
        public int CurrentSetNumber
        {
            get
            {
                if (SetWins != null && _currentSetNumber < 0)
                    _currentSetNumber = SetWins[0] + SetWins[1];
                return _currentSetNumber;
            }
        }
    }
}