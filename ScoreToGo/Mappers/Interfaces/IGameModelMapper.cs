using ScoreToGo.Models;
using STGBusiness.DomainModels;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IGameModelMapper
    {
        GameModel Map(Game domainGame);

        Game Map(GameModel gameModel);
    }
}
