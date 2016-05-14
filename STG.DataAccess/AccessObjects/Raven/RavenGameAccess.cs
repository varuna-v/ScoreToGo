using STG.DataAccess.AccessObjects.Interfaces;
using STG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenGameAccess : RavenDataAccess, IGameAccess
    {
        public Game GetGame(int id)
        {
            return GetFirst<Game>(g => g.Id == id);
        }

        public GamePlay GetGamePlay(int id)
        {
            var game = GetGame(id);
            return game == null ? null : game.GamePlay;
        }

        public void Save(GamePlay gamePlay)
        {
            var game = GetGame(gamePlay.GameId);
            game.GamePlay = gamePlay;
            Save(game);
        }

        public void Save(Game game)
        {
            base.Save(game);
        }
    }
}
