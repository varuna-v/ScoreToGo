using STG.Domain.Models;
namespace ScoreToGo.ViewModels
{
    public class GamePlayViewModel
    {
        public GamePlayViewModel()
        {

        }
        public GamePlayViewModel(GamePlay gamePlay)
        {
            GamePlay = gamePlay;
            TeamRotation[] currentRotation = gamePlay.Sets[gamePlay.CurrentSetNumber].TeamRotations;
            int[] teamARotation = currentRotation[0].ShirtNumbers;
            int[] teamBRotation = currentRotation[1].ShirtNumbers;
            RotationForView = new TeamRotation[2]
            {
                new TeamRotation()
                {
                    ShirtNumbers = new int[6]
                    {
                        teamARotation[4],
                        teamARotation[5],
                        teamARotation[0],
                        teamARotation[3],
                        teamARotation[2],
                        teamARotation[1]
                    }
                } ,
                new TeamRotation()
                {
                    ShirtNumbers = new int[6]
                    {
                        teamBRotation[1],
                        teamBRotation[2],
                        teamBRotation[3],
                        teamBRotation[0],
                        teamBRotation[5],
                        teamBRotation[4]
                    }
                }
            };
        }

        public GamePlay GamePlay { get; set; }

        public TeamRotation[] RotationForView { get; set; }
    }
}