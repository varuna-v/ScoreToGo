﻿using STGBusiness.DomainModels;

namespace STGBusiness.Logic.Interfaces
{
    public interface IGameBusiness
    {
        Game StartGame(int bestOfNumberOfSets);

        AddPointResult AddPoint(Game game, int pointWinner);

        Game StartNewSet(Game game, TeamRotation[] teamRotations);
    }
}
