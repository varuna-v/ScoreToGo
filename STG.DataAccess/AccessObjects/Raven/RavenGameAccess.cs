using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenGameAccess : RavenAccessBase, IGameAccess
    {
        public Game GetGame(int id)
        {
            return Retreive<DataModels.Game>(g => g.Id == id);
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
            Store(game);
        }

        public void Save(DataModels.Game game)
        {
            Store(game);
        }
    }
}
