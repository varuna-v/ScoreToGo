using ScoreToGo.Mappers.Interfaces;
using ScoreToGo.ViewModels;
using STG.Business.DomainModels;
using STG.Domain.Models;
using System;

namespace ScoreToGo.Mappers
{
    public class GamePlayModelMapper : IGamePlayModelMapper
    {
        public GamePlayModel Map(GamePlay Game)
        {
            var gameModel = new GamePlayModel();

            if (Game.Sets != null)
            {
                gameModel.Sets = new SetModel[Game.Sets.Length];
                for (int setNumber = 0; setNumber < Game.Sets.Length; setNumber++)
                {
                    if (Game.Sets[setNumber] != null)
                    {
                        gameModel.Sets[setNumber] = new SetModel { 
                                                                    Score = Game.Sets[setNumber].Score,
                                                                    FirstServer = Game.Sets[setNumber].FirstServer,
                                                                    Winner = Game.Sets[setNumber].Winner 
                                                                 };

                        gameModel.Sets[setNumber].TeamRotations = new TeamRotationModel[2];
                        gameModel.Sets[setNumber].TeamRotations[0] = new TeamRotationModel();
                        gameModel.Sets[setNumber].TeamRotations[0].ShirtNumbers = Game.Sets[setNumber].TeamRotations[0].ShirtNumbers;
                        gameModel.Sets[setNumber].TeamRotations[1] = new TeamRotationModel();
                        gameModel.Sets[setNumber].TeamRotations[1].ShirtNumbers = Game.Sets[setNumber].TeamRotations[1].ShirtNumbers;                        
                    }
                }
            }

            gameModel.SetWins = Game.SetWins;
           
            return gameModel;
        }

        public GamePlay Map(GamePlayModel gameModel)
        {
            var game = new GamePlay();

            if (gameModel.Sets != null)
            {
                game.Sets = new Set[gameModel.Sets.Length];
                for (int setNumber = 0; setNumber < gameModel.Sets.Length; setNumber++)
                {
                    if (gameModel.Sets[setNumber] != null)
                    {
                        game.Sets[setNumber] = new Set { 
                                                                 Score = gameModel.Sets[setNumber].Score, 
                                                                 FirstServer = gameModel.Sets[setNumber].FirstServer,
                                                                 Winner = gameModel.Sets[setNumber].Winner 
                                                             };

                        game.Sets[setNumber].TeamRotations = new TeamRotation[2];
                        game.Sets[setNumber].TeamRotations[0] = new TeamRotation();
                        game.Sets[setNumber].TeamRotations[0].ShirtNumbers = gameModel.Sets[setNumber].TeamRotations[0].ShirtNumbers;
                        game.Sets[setNumber].TeamRotations[1] = new TeamRotation();
                        game.Sets[setNumber].TeamRotations[1].ShirtNumbers = gameModel.Sets[setNumber].TeamRotations[1].ShirtNumbers;
                    }
                }
            }
            
            game.SetWins = gameModel.SetWins;

            return game;
        }
    }
}