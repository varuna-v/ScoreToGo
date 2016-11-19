using STG.DataAccess.Interfaces;
using STG.Domain.Models;

namespace STG.DataAccess.Raven
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
