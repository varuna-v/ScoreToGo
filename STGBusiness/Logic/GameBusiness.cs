using STG.Business.DomainModels;
using STG.Business.Logic.Interfaces;
using STG.Business.Mappers;
using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.DataModels;
using System;

namespace STG.Business.Logic
{
    public class GameBusiness : IGameBusiness
    {
        private readonly IGameAccess _gameAccess;

        private readonly IModelMapper<DomainGamePlay, GamePlay> _gamePlayMapper;

        private readonly IModelMapper<DomainGame, Game> _gameMapper;

        public GameBusiness(IGameAccess gameAccess, IModelMapper<DomainGamePlay, GamePlay> gamePlayMapper, IModelMapper<DomainGame, Game> gameMapper)
        {
            _gameAccess = gameAccess;
            _gamePlayMapper = gamePlayMapper;
            _gameMapper = gameMapper;
        }

        public DomainGame StartGame(int bestOfNumberOfSets, DomainTeamRotation[] teamRotations, int firstServe)
        {
            if (bestOfNumberOfSets % 2 == 0)
                throw new ArgumentException("Best of number of sets must be odd", "bestOfNumberOfSets");
            var game = new DomainGame
            {
                GamePlay = new DomainGamePlay
                {
                    Sets = new DomainSet[bestOfNumberOfSets],
                    SetWins = new int[2]
                },
                StartedAt = DateTime.Now
            };
            game.GamePlay = StartNewSet(game.GamePlay, teamRotations, firstServe);
            Save(game);
            return game;
        }

        public AddPointResult AddPoint(DomainGamePlay game, int pointWinner, int thisPointsServer)
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

        public DomainGamePlay StartNewSet(DomainGamePlay game, DomainTeamRotation[] teamRotations, int firstServe)
        {
            var highestActivatedSetNumber = game.GetHighestActivatedSetNumber();
            game.Sets[highestActivatedSetNumber + 1] = new DomainSet
                                                            {
                                                                TeamRotations = teamRotations,
                                                                Score = new int[2],
                                                                FirstServer = firstServe,
                                                                StartedAt = DateTime.Now
                                                            };
            return game;
        }

        private int GetNewSetsFirstServer(DomainGamePlay game, int highestActivatedSetNumber)
        {
            return game.Sets[highestActivatedSetNumber].FirstServer == 0 ? 1 : 0;
        }

        private DomainGamePlay FinishCurrentSet(DomainGamePlay game, int currentSetNumber, int pointWinner)
        {
            game.Sets[currentSetNumber].Winner = pointWinner;
            game.Sets[currentSetNumber].EndedAt = DateTime.Now;
            game.SetWins[pointWinner]++;
            return game;
        }

        private DomainGamePlay FinishGame(DomainGamePlay game)
        {
            game.EndedAt = DateTime.Now;
            return game;
        }

        private DomainTeamRotation Rotate(DomainTeamRotation model)
        {
            if (model == null || model.ShirtNumbers == null || model.ShirtNumbers.Length != 6)
                throw new ArgumentException("Invalid team rotation model");

            DomainTeamRotation rotatedModel = new DomainTeamRotation();
            rotatedModel.ShirtNumbers = new int[6];
            rotatedModel.ShirtNumbers[0] = model.ShirtNumbers[1];
            rotatedModel.ShirtNumbers[1] = model.ShirtNumbers[2];
            rotatedModel.ShirtNumbers[2] = model.ShirtNumbers[3];
            rotatedModel.ShirtNumbers[3] = model.ShirtNumbers[4];
            rotatedModel.ShirtNumbers[4] = model.ShirtNumbers[5];
            rotatedModel.ShirtNumbers[5] = model.ShirtNumbers[0];
            return rotatedModel;
        }

        private void Save(DomainGamePlay gamePlay)
        {
            DataAccess.DataModels.GamePlay gameToStore = _gamePlayMapper.Map(gamePlay);
            _gameAccess.Save(gameToStore);
        }

        private void Save(DomainGame game)
        {
            Game gameToStore = _gameMapper.Map(game);
            _gameAccess.Save(gameToStore);
        }
    }
}
