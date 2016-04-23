using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace STG.DataAccess.AccessObjects.Raven
{
    public class RavenTeamAccess : RavenAccessBase, ITeamAccess
    {
        public List<Team> GetAllTeams()
        {
            var teams = RetreiveCollection<Team>(t => true);
            if (teams == null)
                return null;
            return teams.ToList();
        }

        public Team GetTeam(int id)
        {
            return Retreive<DataModels.Team>(t => t.Id == id);
        }

        public void AddTeam(Team team)
        {
            Store(team);
        }
    }
}
