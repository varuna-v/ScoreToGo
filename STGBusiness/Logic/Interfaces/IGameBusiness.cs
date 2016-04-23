using STG.Business.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGBusiness.Logic.Interfaces
{
    public interface IGameBusiness
    {
        DomainGame GetInitailGame();
    }
}
