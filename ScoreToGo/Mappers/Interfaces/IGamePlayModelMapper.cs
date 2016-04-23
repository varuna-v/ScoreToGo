using ScoreToGo.Models;
using STG.Business.DomainModels;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IGamePlayModelMapper
    {
        GamePlayModel Map(DomainGamePlay domainGame);

        DomainGamePlay Map(GamePlayModel gameModel);
    }
}
