using STG.Business.DomainModels;
using System.Collections.Generic;

namespace STG.Business.Logic.Interfaces
{
    public interface ITeamBusiness
    {
        List<DomainTeam> GetTeams();
    }
}
