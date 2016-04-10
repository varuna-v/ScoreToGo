using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.Connections;
using STG.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects
{
    public class GameAccess : IGameAccess
    {
        private IDatabaseConnection _connection;

        public GameAccess(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public Game Get(int id)
        {
            var query = "SELECT * "+
                        "FROM Game G" +
                        "JOIN GamePlayer GP" +
                        "JOIN Player P"
        }

        public void Add(Game game)
        {
            throw new NotImplementedException();
        }

        public void Update(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
