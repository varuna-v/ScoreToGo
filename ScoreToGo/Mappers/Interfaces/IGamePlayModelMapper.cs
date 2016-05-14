using ScoreToGo.ViewModels;
using STG.Business.DomainModels;
using STG.Domain.Models;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IGamePlayModelMapper
    {
        GamePlayModel Map(GamePlay Game);

        GamePlay Map(GamePlayModel gameModel);
    }
}
