using Nelibur.ObjectMapper;
using ScoreToGo.Models;
using STG.Business.DomainModels;
using STG.Business.Mappers;

namespace ScoreToGo.Mappers
{
    public class GameModelMapper : IModelMapper<GameModel, DomainGame>
    {
        public GameModel Map(DomainGame source)
        {
            TinyMapper.Bind<DomainGame, GameModel>();
            var result = TinyMapper.Map<GameModel>(source);
            return result;
        }

        public DomainGame Map(GameModel source)
        {
            TinyMapper.Bind<GameModel, DomainGame>();
            var result = TinyMapper.Map<DomainGame>(source);
            return result;
        }
    }
}