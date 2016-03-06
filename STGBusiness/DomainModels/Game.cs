using System;
namespace STGBusiness.DomainModels
{
    public class Game
    {
        public Set[] Sets { get; set; }

        public int[] SetWins { get; set; }

        private int _targetNumberOfSetsToWinGame;
        private int TargetNumberOfSetsToWinGame
        {
            get
            {
                if (_targetNumberOfSetsToWinGame <= 1)
                    _targetNumberOfSetsToWinGame = (int)((Sets.Length + 1) / 2);
                return _targetNumberOfSetsToWinGame;
            }
        }

        public bool IsEndOfSet(int currentSetNumber)
        {
            var score0 = Sets[currentSetNumber].Score[0];
            var score1 = Sets[currentSetNumber].Score[1];
            var targetScore = currentSetNumber == Sets.Length - 1 ? 15 : 25;
            return (score0 >= targetScore || score1 >= targetScore) && Math.Abs(score0 - score1) >= 2;
        }

        public bool IsEndOfGame()
        {
            return SetWins != null && (SetWins[0] == TargetNumberOfSetsToWinGame || SetWins[1] == TargetNumberOfSetsToWinGame);
        }

        public bool IsNextSetDeciding()
        {
            return SetWins != null && SetWins[0] == TargetNumberOfSetsToWinGame - 1 && SetWins[1] == TargetNumberOfSetsToWinGame - 1;
        }

        public int GetHighestActivatedSetNumber()
        {
            for (int setNumber = Sets.Length - 1; setNumber >= 0; setNumber--)
            {
                if (Sets[setNumber] != null && Sets[setNumber].Score != null)
                    return setNumber;
            }
            return -1;
        }
    }
}
