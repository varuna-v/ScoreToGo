using STG.Domain.Models;
using System;

namespace STG.Business.Interfaces
{
    public interface IGamePlayBusiness
    {
        Game StartGame(int bestOfNumberOfSets, TeamRotation[] teamRotations, int firstServe);

        AddPointResult AddPoint(GamePlay game, int pointWinner, int thisPointsServer);

        GamePlay StartNewSet(GamePlay game, TeamRotation[] teamRotations, int firstServe);

        GameUpdateResult Substitute(GamePlay game, int team, int shirtNumberGoingIn, int shirtNumberComingOut);

        GameUpdateResult LogTimeOut(GamePlay gamePlay, int team);

        Game GetGame(Guid id);
    }
}
