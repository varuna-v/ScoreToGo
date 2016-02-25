using ScoreToGo.Mappers.Interfaces;
using ScoreToGo.Models;
using STGBusiness.DomainModels;
using System;

namespace ScoreToGo.Mappers
{
    public class GameModelMapper : IGameModelMapper
    {
        public GameModel Map(Game domainGame)
        {
            var gameModel = new GameModel();

            if (domainGame.Sets != null)
            {
                gameModel.Sets = new SetModel[5];
                for(int setNumber = 0; setNumber < 5; setNumber++)
                {
                    if (domainGame.Sets[setNumber] != null)
                    {
                        gameModel.Sets[setNumber] = new SetModel { Score = domainGame.Sets[setNumber].Score, Winner = domainGame.Sets[setNumber].Winner };

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

        public Game Map(GameModel gameModel)
        {
            var domainGame = new Game();

            if (gameModel.Sets != null)
            {
                domainGame.Sets = new Set[5];
                for (int setNumber = 0; setNumber < 5; setNumber++)
                {
                    if (gameModel.Sets[setNumber] != null)
                    {
                        domainGame.Sets[setNumber] = new Set { Score = gameModel.Sets[setNumber].Score, Winner = gameModel.Sets[setNumber].Winner };

                        domainGame.Sets[setNumber].TeamRotations = new TeamRotation[2];
                        domainGame.Sets[setNumber].TeamRotations[0] = new TeamRotation();
                        domainGame.Sets[setNumber].TeamRotations[0].ShirtNumbers = gameModel.Sets[setNumber].TeamRotations[0].ShirtNumbers;
                        domainGame.Sets[setNumber].TeamRotations[1] = new TeamRotation();
                        domainGame.Sets[setNumber].TeamRotations[1].ShirtNumbers = gameModel.Sets[setNumber].TeamRotations[1].ShirtNumbers;
                    }
                }
            }
            
            domainGame.SetWins = gameModel.SetWins;

            return domainGame;
        }
    }
}