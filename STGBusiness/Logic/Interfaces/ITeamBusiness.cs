using STG.Domain.Models;
using System.Collections.Generic;

namespace STG.Business.Logic.Interfaces
{
    public interface ITeamBusiness
    {
        List<Team> GetAllTeams();
    }
}
