using STG.Domain.Models;
using System;

namespace STG.DataAccess.Interfaces
{
    public interface IGameAccess
    {
        Game GetGame(Guid id);
        void Save(GamePlay gamePlay);
        void Save(Game game);
    }
}
