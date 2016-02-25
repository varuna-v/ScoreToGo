using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreToGo.Models;
using STGBusiness.DomainModels;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IRotationModelMapper
    {
        Rotation Map(RotationModel rotationModel);
        RotationModel Map(Rotation domainModel);
    }
}
