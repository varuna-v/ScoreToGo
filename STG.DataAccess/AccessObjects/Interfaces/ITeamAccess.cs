using STG.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG.DataAccess.AccessObjects.Interfaces
{
    public interface ITeamAccess
    {
        Team GetTeam();
        void AddTeam(Team team);
    }
}
