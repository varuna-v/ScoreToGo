using STG.Business.DomainModels;

namespace STG.Business.Logic.Interfaces
{
    public interface IGameBusiness
    {
        DomainGame StartGame(int bestOfNumberOfSets, DomainTeamRotation[] teamRotations, int firstServe);

        AddPointResult AddPoint(DomainGamePlay game, int pointWinner, int thisPointsServer);

        DomainGamePlay StartNewSet(DomainGamePlay game, DomainTeamRotation[] teamRotations, int firstServe);

        //DomainGame GetGame(int gameId);
    }
}
