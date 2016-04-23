using STG.Business.DomainModels;
using STG.DataAccess.AccessObjects.Interfaces;
using STG.DataAccess.DataModels;
using STG.Business.Logic.Interfaces;
using STG.Business.Mappers;
using System.Collections.Generic;

namespace STG.Business.Logic
{
    public class TeamBusiness : ITeamBusiness
    {
        private readonly IMapper _mapper;

        private readonly ITeamAccess _teamAccess;

        public TeamBusiness(IMapper mapper, ITeamAccess teamAccess)
        {
            _mapper = mapper;
            _teamAccess = teamAccess;
        }

        public List<STG.Business.DomainModels.DomainTeam> GetTeams()
        {
            var teams = _teamAccess.GetAllTeams();
            var domainTeams = _mapper.Map<List<Team>, List<DomainTeam>>(teams);
            return domainTeams;
        }
    }
}
