using STG.Business.Interfaces;
using STG.DataAccess.Interfaces;
using STG.Domain.Mappers;
using STG.Domain.Models;
using System;
using STG.Domain.Extensions;
using System.Linq;

namespace STG.Business
{
    //todo take GamePlay in by reference so don't need to return from methods?
    public class GamePlayBusiness : IGamePlayBusiness
    {
        private readonly IGameAccess _gameAccess;

        public GamePlayBusiness(IGameAccess gameAccess)
        {
            _gameAccess = gameAccess;
        }

        public Game StartGame(int bestOfNumberOfSets, TeamRotation[] teamRotations, int firstServe)
        {
            if (bestOfNumberOfSets % 2 == 0)
                throw new ArgumentException("Best of number of sets must be odd", "bestOfNumberOfSets");
            var game = new Game
            {
                GamePlay = new GamePlay
                {
                    Sets = new Set[bestOfNumberOfSets],
                    SetWins = new int[2]
                },
                StartedAt = DateTime.Now
            };
            game.GamePlay = StartNewSet(game.GamePlay, teamRotations, firstServe);
            Save(game);
            return game;
        }

        public AddPointResult AddPoint(GamePlay game, int pointWinner, int thisPointsServer)
        {
            var currentSetNumber = game.GetHighestActivatedSetNumber();
            game.Sets[currentSetNumber].Score[pointWinner]++;

            if (thisPointsServer > -1 && pointWinner != thisPointsServer)
                game.Sets[currentSetNumber].TeamRotations[pointWinner] = Rotate(game.Sets[currentSetNumber].TeamRotations[pointWinner]);

            if (game.IsEndOfSet(currentSetNumber))
            {
                game = FinishCurrentSet(game, currentSetNumber, pointWinner);
                if (game.IsEndOfGame())
                {
                    game = FinishGame(game);
                    return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfGame };
                }
                if (game.IsNextSetDeciding())
                    return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSetNextDeciding };

                return new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSet, NextServer = GetNewSetsFirstServer(game, currentSetNumber) };
            }
            return new AddPointResult { Game = game, ResultStatus = PointResultStatus.Continue, NextServer = pointWinner };
        }

        public GamePlay StartNewSet(GamePlay game, TeamRotation[] teamRotations, int firstServe)
        {
            var highestActivatedSetNumber = game.GetHighestActivatedSetNumber();
            game.Sets[highestActivatedSetNumber + 1] = new Set
                                                            {
                                                                TeamRotations = teamRotations,
                                                                Score = new int[2],
                                                                FirstServer = firstServe,
                                                                StartedAt = DateTime.Now,
                                                                Information = new TeamInSetInformation[2] { new TeamInSetInformation(), new TeamInSetInformation() }
                                                            };
            return game;
        }

        public void Substitute(GamePlay game, int team, int shirtNumberGoingIn, int positionOfPlayerComingOut)
        {
            //!!Validation
            // team in 0, 1
            // team contains shirt coming out
            // no. of substitutions done for team for set
            // new shirt number isn't already there
            Set currentSet = game.GetCurrentSet();
            int opponentTeam = team == 1 ? 0 : 1; //reapeted logic??
            var substitution = new Substitution
            {
                OpponentScore = currentSet.Score[opponentTeam],
                PlayerComingOut = currentSet.TeamRotations[team].ShirtNumbers[positionOfPlayerComingOut],
                PlayerGoingIn = shirtNumberGoingIn,
                RequestedTeamScore = currentSet.Score[team]
            };
            currentSet.Information[team].Substitutions.Add(substitution);
            currentSet.TeamRotations[team].ShirtNumbers[positionOfPlayerComingOut] = shirtNumberGoingIn;
        }

        private int GetNewSetsFirstServer(GamePlay game, int highestActivatedSetNumber)
        {
            return game.Sets[highestActivatedSetNumber].FirstServer == 0 ? 1 : 0;
        }

        private GamePlay FinishCurrentSet(GamePlay game, int currentSetNumber, int pointWinner)
        {
            game.Sets[currentSetNumber].Winner = pointWinner;
            game.Sets[currentSetNumber].EndedAt = DateTime.Now;
            game.SetWins[pointWinner]++;
            return game;
        }

        private GamePlay FinishGame(GamePlay game)
        {
            game.EndedAt = DateTime.Now;
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

        private void Save(GamePlay gamePlay) //!! never used
        {
            _gameAccess.Save(gamePlay);
        }

        private void Save(Game game)
        {
            _gameAccess.Save(game);
        }

    }
}
