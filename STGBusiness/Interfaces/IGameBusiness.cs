using STG.Domain.Models;

namespace STG.Business.Interfaces
{
    public interface IGameBusiness
    {
        Game GetInitialGame();
        Game GetGame(int gameId);
    }
}
