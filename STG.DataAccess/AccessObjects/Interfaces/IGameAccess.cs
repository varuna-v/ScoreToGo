using STG.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Interfaces
{
    public interface IGameAccess
    {
        Game GetGame(int id);
        GamePlay GetGamePlay(int id);
        void Save(Game game);
        void Save(GamePlay gamePlay);
    }
}
