using STG.Domain.Models;

namespace STG.Business.Interfaces
{
   public  interface IGameStatsBusiness
    {
        GameStats GetGameStats(Game game);
    }
}
