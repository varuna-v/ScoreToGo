using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STG.Business.DomainModels;
using STG.Business.Logic.Interfaces;

namespace STG.Business.Logic
{
    public class GameBusiness : IGameBusiness
    {
        public Game StartGame(int bestOfNumberOfSets, TeamRotation[] teamRotations, int firstServe)
        {
            if (bestOfNumberOfSets % 2 == 0)
                throw new ArgumentException("Best of number of sets must be odd", "bestOfNumberOfSets");
            var game = new Game
            {
                Sets = new Set[bestOfNumberOfSets],
                SetWins = new int[2]
            };
            game = StartNewSet(game, teamRotations, firstServe);
            return game;
        }

        public AddPointResult AddPoint(Game game, int pointWinner, int thisPointsServer)
        {
            var currentSetNumber = game.GetHighestActivatedSetNumber();
            game.Sets[currentSetNumber].Score[pointWinner]++;

            if (thisPointsServer > -1 && pointWinner != thisPointsServer)
                game.Sets[currentSetNumber].TeamRotations[pointWinner] = Rotate(game.Sets[currentSetNumber].TeamRotations[pointWinner]);

            if (game.IsEndOfSet(currentSetNumber))
            {
                game = FinishCurrentSet(game, currentSetNumber, pointWinner);
                if (game.IsEndOfGame())
                    return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfGame };
                if (game.IsNextSetDeciding())
                    return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSetNextDeciding };

                return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSet, NextServer = GetNewSetsFirstServer(game, currentSetNumber) };
            }
            return new AddPointResult { Game = game, ResultStatus = PointResultStatus.Continue, NextServer = pointWinner };
        }

        public Game StartNewSet(Game game, TeamRotation[] teamRotations, int firstServe)
        {
            var highestActivatedSetNumber = game.GetHighestActivatedSetNumber();
            game.Sets[highestActivatedSetNumber + 1] = new Set
                                                            {
                                                                TeamRotations = teamRotations,
                                                                Score = new int[2],
                                                                FirstServer = firstServe
                                                            };
            return game;
        }

        private int GetNewSetsFirstServer(Game game, int highestActivatedSetNumber)
        {
            return game.Sets[highestActivatedSetNumber].FirstServer == 0 ? 1 : 0;
        }

        private Game FinishCurrentSet(Game game, int currentSetNumber, int pointWinner)
        {
            game.Sets[currentSetNumber].Winner = pointWinner;
            game.SetWins[pointWinner]++;
            return game;
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
