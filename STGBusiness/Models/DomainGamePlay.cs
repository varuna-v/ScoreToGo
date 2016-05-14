using System;
using STG.Domain.Models;

namespace STG.Business.Models
{
    //!! rename?? GamePlayLogicModel?
    public class DomainGamePlay : GamePlay
    {
        
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
//!! game model and a gameplay model to reduce mapping?