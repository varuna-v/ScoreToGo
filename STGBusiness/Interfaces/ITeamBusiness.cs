using STG.Domain.Models;
using System.Collections.Generic;

namespace STG.Business.Interfaces
{
    public interface ITeamBusiness
    {
        List<Team> GetAllTeams();
    }
}
