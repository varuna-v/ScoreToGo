using Nelibur.ObjectMapper;
using STG.Business.DomainModels;
using STG.DataAccess.DataModels;
using System;

namespace STG.Business.Mappers.DomainAndDataAccess
{
    public class GameMapper : IModelMapper<DomainGame, Game>
    {
        private readonly IModelMapper<DomainGamePlay, GamePlay> _gamePlayMapper;
        //private IMapper _teamArrayMapper;

        public GameMapper(IModelMapper<DomainGamePlay, GamePlay> gamePlayMapper)
        {
           // var configuration = new MapperConfiguration(c => c.CreateMap<DomainTeam[], STG.DataAccess.DataModels.Team[]>());
            //_teamArrayMapper = configuration.CreateMapper();
            _gamePlayMapper = gamePlayMapper;
        }

        public Game Map(DomainGame source)
        {
            Game result = new Game();
            result.Teams = MapTeams(source.Teams);
            result.GamePlay = _gamePlayMapper.Map(source.GamePlay);
            result.StartedAt = source.StartedAt;
            return result;
        }

        private STG.DataAccess.DataModels.Team[] MapTeams(DomainTeam[] sourceTeams)
        {
            TinyMapper.Bind<DomainTeam[], Team[]>();
            if (sourceTeams == null)
                return null;
            STG.DataAccess.DataModels.Team[] targetTeams = TinyMapper.Map<Team[]>(sourceTeams);
            return targetTeams;
        }


        public DomainGame Map(Game source)
        {
            throw new NotImplementedException();
        }
    }
}
