using STG.Business.DomainModels;

namespace STG.Business.Logic.Interfaces
{
    public interface IGameBusiness
    {
        Game StartGame(int bestOfNumberOfSets, TeamRotation[] teamRotations, int firstServe);

        AddPointResult AddPoint(Game game, int pointWinner, int thisPointsServer);

        Game StartNewSet(Game game, TeamRotation[] teamRotations, int firstServe);
    }
}
