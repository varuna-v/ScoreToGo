using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STGBusiness.DomainModels;

namespace STGBusiness.Logic.Interfaces
{
    public interface IRotationBusiness
    {
        Rotation Rotate(Rotation model, int pointWinner);
    }
}
