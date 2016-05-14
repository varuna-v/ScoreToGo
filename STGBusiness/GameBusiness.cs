using STG.Business.Interfaces;
using STG.Domain.Models;
using System;

namespace STG.Business
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
