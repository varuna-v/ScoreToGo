﻿using STG.Domain.Models;

namespace STG.DataAccess.Interfaces
{
    public interface IGameAccess
    {
        Game GetGame(int id);
        GamePlay GetGamePlay(int id);
        void Save(GamePlay gamePlay);
        void Save(Game game);
    }
}