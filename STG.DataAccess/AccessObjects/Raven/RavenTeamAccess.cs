using STG.DataAccess.AccessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenTeamAccess : RavenAccessBase, ITeamAccess
    {
        public DataModels.Team GetTeam()
        {
            throw new NotImplementedException();
        }

        public void AddTeam(DataModels.Team team)
        {
            Store(team);
        }
    }
}
