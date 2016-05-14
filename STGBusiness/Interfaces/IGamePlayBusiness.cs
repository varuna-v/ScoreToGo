using STG.Domain.Models;

namespace STG.Business.Interfaces
{
    public interface IGamePlayBusiness
    {
        Game StartGame(int bestOfNumberOfSets, TeamRotation[] teamRotations, int firstServe);

        AddPointResult AddPoint(GamePlay game, int pointWinner, int thisPointsServer);

        GamePlay StartNewSet(GamePlay game, TeamRotation[] teamRotations, int firstServe);               
    }
}
