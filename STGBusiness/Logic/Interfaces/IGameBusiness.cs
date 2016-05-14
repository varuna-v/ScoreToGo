using STG.Domain.Models;

namespace STG.Business.Logic.Interfaces
{
    public interface IGameBusiness
    {
        Game GetInitialGame();
        Game GetGame(int gameId);
    }
}
