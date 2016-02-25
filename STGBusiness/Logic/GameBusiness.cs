using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STGBusiness.DomainModels;
using STGBusiness.Logic.Interfaces;

namespace STGBusiness.Logic
{
    public class GameBusiness : IGameBusiness
    {
        public Game StartGame(int bestOfNumberOfSets)
        {
            if (bestOfNumberOfSets % 2 == 0)
                throw new ArgumentException("Best of number of sets must be odd", "bestOfNumberOfSets");
            var game = new Game
            {
                Sets = new Set[bestOfNumberOfSets],
                SetWins = new int[2]
            };
            return game;
        }

        public AddPointResult AddPoint(Game game, int pointWinner)
        {
            var currentSetNumber = GetHighestActivatedSetNumber(game);
            game.Sets[currentSetNumber].Score[pointWinner]++;
            game.Sets[currentSetNumber].TeamRotations[pointWinner] = Rotate(game.Sets[currentSetNumber].TeamRotations[pointWinner]);

            if (IsEndOfSet(game, currentSetNumber))
            {
                game = FinishCurrentSet(game, currentSetNumber, pointWinner);
                if (IsEndOfGame(game))
                    return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfGame };

                return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSet };
            }
            return new AddPointResult { Game = game, ResultStatus = PointResultStatus.Continue };
        }

        public Game StartNewSet(Game game, TeamRotation[] teamRotations)
        {
            var highestActivatedSetNumber = GetHighestActivatedSetNumber(game);
            game.Sets[highestActivatedSetNumber + 1] = new Set
            {
                TeamRotations = teamRotations,
                Score = new int[2]

            };
            return game;
        }

        private Game FinishCurrentSet(Game game, int currentSetNumber, int pointWinner)
        {
            game.Sets[currentSetNumber].Winner = pointWinner;
            game.SetWins[pointWinner]++;
            return game;
        }

        private bool IsEndOfSet(Game game, int currentSetNumber)
        {
            var score0 = game.Sets[currentSetNumber].Score[0];
            var score1 = game.Sets[currentSetNumber].Score[1];
            var targetScore = currentSetNumber == game.Sets.Length ? 15 : 25;
            return (score0 > targetScore || score1 > targetScore) && Math.Abs(score0 - score1) >= 2;
        }

        private bool IsEndOfGame(Game game)
        {
            return game.SetWins != null && Math.Abs(game.SetWins[0] - game.SetWins[1]) >= game.TargetNumberOfSets;
        }

        private int GetHighestActivatedSetNumber(Game game)
        {
            for (int setNumber = 4; setNumber >= 0; setNumber--)
            {
                if (game.Sets[setNumber] != null && game.Sets[setNumber].Score != null)
                    return setNumber;
            }
            return -1;
        }

        private TeamRotation Rotate(TeamRotation model)
        {
            if (model == null || model.ShirtNumbers == null || model.ShirtNumbers.Length != 6)
                throw new ArgumentException("Invalid team rotation model");

            TeamRotation rotatedModel = new TeamRotation();
            rotatedModel.ShirtNumbers = new int[6];
            rotatedModel.ShirtNumbers[0] = model.ShirtNumbers[1];
            rotatedModel.ShirtNumbers[1] = model.ShirtNumbers[2];
            rotatedModel.ShirtNumbers[2] = model.ShirtNumbers[3];
            rotatedModel.ShirtNumbers[3] = model.ShirtNumbers[4];
            rotatedModel.ShirtNumbers[4] = model.ShirtNumbers[5];
            rotatedModel.ShirtNumbers[5] = model.ShirtNumbers[0];
            return rotatedModel;
        }

    }
}
