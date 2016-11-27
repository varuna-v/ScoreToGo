using STG.DataAccess.Interfaces;
using STG.Domain.Models;
using System;

namespace STG.DataAccess.Raven
{
    public class RavenGameAccess : RavenDataAccess, IGameAccess
    {
        public Game GetGame(Guid id)
        {
            return Load<Game>(GetDocumentId(id));
        }

        public void Save(GamePlay gamePlay)
        {
            var game = Load<Game>(GetDocumentId(gamePlay.GameId));
            game.GamePlay = gamePlay;
            Save(game);
        }

        public void Save(Game game)
        {
            base.Save(game);
        }

        private string GetDocumentId(Guid gameId)
        {
            return $"{new Game().IdPrefix}/{gameId}";
        }
    }
}
