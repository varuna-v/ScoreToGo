using STG.Business.Logic.Interfaces;
using STG.Domain.Models;
using System;

namespace STG.Business.Logic
{
    public class GameBusiness : IGameBusiness
    {
        public Game GetInitialGame()
        {
            var game = new Game()
            {
                StartedAt = DateTime.Now,
                Teams = new Team[2]
            };
            return game;
        }

        public Game GetGame(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
