using STG.Business.Logic.Interfaces;
using STG.DataAccess.AccessObjects.Interfaces;
using STG.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace STG.Business.Logic
{
    public class TeamBusiness : ITeamBusiness
    {
        private readonly IAccessData _dataAccess;

        public TeamBusiness(IAccessData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<Team> GetAllTeams()
        {
            var teams = _dataAccess.GetAll<Team>().ToList();
            return teams;
        }
    }
}
