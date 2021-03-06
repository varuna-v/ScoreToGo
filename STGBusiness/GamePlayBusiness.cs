﻿using STG.Business.Interfaces;
using STG.DataAccess.Interfaces;
using STG.Domain.Models;
using System;
using STG.Domain.Extensions;
using STG.Domain;

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
            Guid gameId = Guid.NewGuid();
            var game = new Game
            {
                UniqueId = gameId,
                GamePlay = new GamePlay
                {
                    GameId = gameId,
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
            AddPointResult result = new AddPointResult { Game = game, ResultStatus = PointResultStatus.Continue, NextServer = pointWinner };
            if (game.IsEndOfSet(currentSetNumber))
            {
                FinishCurrentSet(game, currentSetNumber, pointWinner);
                if (game.IsEndOfGame())
                {
                    FinishGame(game);
                    result = new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfGame };
                }
                else if (game.IsNextSetDeciding())
                    result = new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSetNextDeciding };
                else
                    result = new AddPointResult { Game = game, ResultStatus = PointResultStatus.EndOfSet, NextServer = GetNewSetsFirstServer(game, currentSetNumber) };
            }
            Save(game);
            return result;
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
                Information = new TeamInSetInformation[2]
                                                                {
                                                                    new TeamInSetInformation() {  Substitutions = new Substitution[Constants.MaximumNumberOfSubstitutionsPerTeamPerSet], TimeOuts = new TimeOut[Constants.MaximumNumberOfTimeOutsPerTeamPerSet] },
                                                                    new TeamInSetInformation() { Substitutions = new Substitution[Constants.MaximumNumberOfSubstitutionsPerTeamPerSet], TimeOuts = new TimeOut[Constants.MaximumNumberOfTimeOutsPerTeamPerSet] }
                                                                },
            };
            return game;
        }

        public GameUpdateResult Substitute(GamePlay game, int team, int shirtNumberGoingIn, int shirtNumberComingOut)
        {
            Set currentSet = game.GetCurrentSet();
            int opponentTeam = team == 1 ? 0 : 1; //repeated logic??
            //!!Validation
            // team in 0, 1
            // team contains shirt coming out
            // no. of substitutions done for team for set
            int completedSubstitutionCount; //!! store this count in the object?
            for (completedSubstitutionCount = 0; completedSubstitutionCount < currentSet.Information[team].Substitutions.Length; completedSubstitutionCount++)
            {
                if (currentSet.Information[team].Substitutions[completedSubstitutionCount] == null)
                    break;
            }
            if (completedSubstitutionCount == 4)
                return GameUpdateResult.LimitExceeced;
            // new shirt number isn't already there
            int positionOfPlayerComingOut = Array.IndexOf(currentSet.TeamRotations[team].ShirtNumbers, shirtNumberComingOut);
            var substitution = new Substitution
            {
                OpponentScore = currentSet.Score[opponentTeam],
                PlayerComingOut = currentSet.TeamRotations[team].ShirtNumbers[positionOfPlayerComingOut],
                PlayerGoingIn = shirtNumberGoingIn,
                RequestedTeamScore = currentSet.Score[team]
            };

            currentSet.Information[team].Substitutions[completedSubstitutionCount++] = substitution;
            currentSet.TeamRotations[team].ShirtNumbers[positionOfPlayerComingOut] = shirtNumberGoingIn;
            Save(game);
            return GameUpdateResult.Success;
        }

        public GameUpdateResult LogTimeOut(GamePlay gamePlay, int team)
        {
            //!! more validation
            Set currentSet = gamePlay.GetCurrentSet();
            TeamInSetInformation teamInSetInformation = currentSet.Information[team];
            if (teamInSetInformation.NumberOfTimeOutsUsed == Constants.MaximumNumberOfTimeOutsPerTeamPerSet)
                return GameUpdateResult.LimitExceeced;
            TimeOut timeOut = new TimeOut
            {
                TeamAScore = currentSet.Score[0],
                TeamBScore = currentSet.Score[1]
            };
            teamInSetInformation.TimeOuts[teamInSetInformation.NumberOfTimeOutsUsed] = timeOut;
            teamInSetInformation.NumberOfTimeOutsUsed++;
            Save(gamePlay);
            return teamInSetInformation.NumberOfTimeOutsUsed == Constants.MaximumNumberOfTimeOutsPerTeamPerSet ? GameUpdateResult.SuccessLastAvailable : GameUpdateResult.Success;
        }

        private int GetNewSetsFirstServer(GamePlay game, int highestActivatedSetNumber)
        {
            return game.Sets[highestActivatedSetNumber].FirstServer == 0 ? 1 : 0;
        }

        private void FinishCurrentSet(GamePlay game, int currentSetNumber, int pointWinner)
        {
            game.Sets[currentSetNumber].Winner = pointWinner;
            game.Sets[currentSetNumber].EndedAt = DateTime.Now;
            game.SetWins[pointWinner]++;
        }

        private void FinishGame(GamePlay gamePlay)
        {
            Game game = GetGame(gamePlay.GameId);
            game.EndedAt = DateTime.Now; //!! utc?
            Save(game);
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

        private void Save(GamePlay gamePlay) 
        {
            _gameAccess.Save(gamePlay);
        }

        private void Save(Game game)
        {
            _gameAccess.Save(game);
        }

        public Game GetGame(Guid id)
        {
            return _gameAccess.GetGame(id);
        }
    }
}
