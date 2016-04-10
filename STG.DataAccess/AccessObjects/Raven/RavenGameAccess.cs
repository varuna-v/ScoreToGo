using STG.DataAccess.AccessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenGameAccess : RavenAccessBase, IGameAccess
    {
        public DataModels.Game Get(int id)
        {
            return Retreive<DataModels.Game>(g => g.Id == id);
        }

        public void Save(DataModels.Game game)
        {
            Store(game);
        }
    }
}
