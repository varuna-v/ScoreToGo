using ScoreToGo.Mappers.Interfaces;
using ScoreToGo.Models;
using STG.Business.DomainModels;
using System;

namespace ScoreToGo.Mappers
{
    public class GamePlayModelMapper : IGamePlayModelMapper
    {
        public GamePlayModel Map(DomainGamePlay domainGame)
        {
            var gameModel = new GamePlayModel();

            if (domainGame.Sets != null)
            {
                gameModel.Sets = new SetModel[domainGame.Sets.Length];
                for (int setNumber = 0; setNumber < domainGame.Sets.Length; setNumber++)
                {
                    if (domainGame.Sets[setNumber] != null)
                    {
                        gameModel.Sets[setNumber] = new SetModel { 
                                                                    Score = domainGame.Sets[setNumber].Score,
                                                                    FirstServer = domainGame.Sets[setNumber].FirstServer,
                                                                    Winner = domainGame.Sets[setNumber].Winner 
                                                                 };

                        gameModel.Sets[setNumber].TeamRotations = new TeamRotationModel[2];
                        gameModel.Sets[setNumber].TeamRotations[0] = new TeamRotationModel();
                        gameModel.Sets[setNumber].TeamRotations[0].ShirtNumbers = domainGame.Sets[setNumber].TeamRotations[0].ShirtNumbers;
                        gameModel.Sets[setNumber].TeamRotations[1] = new TeamRotationModel();
                        gameModel.Sets[setNumber].TeamRotations[1].ShirtNumbers = domainGame.Sets[setNumber].TeamRotations[1].ShirtNumbers;                        
                    }
                }
            }

            gameModel.SetWins = domainGame.SetWins;
           
            return gameModel;
        }

        public DomainGamePlay Map(GamePlayModel gameModel)
        {
            var domainGame = new DomainGamePlay();

            if (gameModel.Sets != null)
            {
                domainGame.Sets = new DomainSet[gameModel.Sets.Length];
                for (int setNumber = 0; setNumber < gameModel.Sets.Length; setNumber++)
                {
                    if (gameModel.Sets[setNumber] != null)
                    {
                        domainGame.Sets[setNumber] = new DomainSet { 
                                                                 Score = gameModel.Sets[setNumber].Score, 
                                                                 FirstServer = gameModel.Sets[setNumber].FirstServer,
                                                                 Winner = gameModel.Sets[setNumber].Winner 
                                                             };

                        domainGame.Sets[setNumber].TeamRotations = new DomainTeamRotation[2];
                        domainGame.Sets[setNumber].TeamRotations[0] = new DomainTeamRotation();
                        domainGame.Sets[setNumber].TeamRotations[0].ShirtNumbers = gameModel.Sets[setNumber].TeamRotations[0].ShirtNumbers;
                        domainGame.Sets[setNumber].TeamRotations[1] = new DomainTeamRotation();
                        domainGame.Sets[setNumber].TeamRotations[1].ShirtNumbers = gameModel.Sets[setNumber].TeamRotations[1].ShirtNumbers;
                    }
                }
            }
            
            domainGame.SetWins = gameModel.SetWins;

            return domainGame;
        }
    }
}