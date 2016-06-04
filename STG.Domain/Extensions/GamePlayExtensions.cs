using STG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.Domain.Extensions
{
    public static class GamePlayExtensions
    {
        public static int TargetNumberOfSetsToWinGame(this GamePlay gamePlay)
        {
            return (int)((gamePlay.Sets.Length + 1M) / 2);
        }

        public static bool IsEndOfSet(this GamePlay gamePlay, int currentSetNumber)
        {
            var score0 = gamePlay.Sets[currentSetNumber].Score[0];
            var score1 = gamePlay.Sets[currentSetNumber].Score[1];
            var targetScore = currentSetNumber == gamePlay.Sets.Length - 1 ? 15 : 25;
            return (score0 >= targetScore || score1 >= targetScore) && Math.Abs(score0 - score1) >= 2;
        }

        public static bool IsEndOfGame(this GamePlay gamePlay)
        {
            int targetNumberOfSetsToWinGame = gamePlay.TargetNumberOfSetsToWinGame();
            return gamePlay.SetWins != null && (gamePlay.SetWins[0] == targetNumberOfSetsToWinGame || gamePlay.SetWins[1] == targetNumberOfSetsToWinGame);
        }

        public static bool IsNextSetDeciding(this GamePlay gamePlay)
        {
            int targetNumberOfSetsToWinGame = gamePlay.TargetNumberOfSetsToWinGame();
            return gamePlay.SetWins != null && gamePlay.SetWins[0] == targetNumberOfSetsToWinGame - 1 && gamePlay.SetWins[1] == targetNumberOfSetsToWinGame - 1;
        }

        public static int GetHighestActivatedSetNumber(this GamePlay gamePlay)
        {
            for (int setNumber = gamePlay.Sets.Length - 1; setNumber >= 0; setNumber--)
            {
                if (gamePlay.Sets[setNumber] != null && gamePlay.Sets[setNumber].Score != null)
                    return setNumber;
            }
            return -1;
        }

        public static Set GetCurrentSet(this GamePlay gamePlay)
        {
            return gamePlay.Sets[gamePlay.GetHighestActivatedSetNumber()];
        }
    }
}
