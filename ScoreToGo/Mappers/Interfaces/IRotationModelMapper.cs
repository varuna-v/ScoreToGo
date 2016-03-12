using ScoreToGo.Models;
using STG.Business.DomainModels;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IRotationModelMapper
    {
        Rotation Map(RotationModel rotationModel);
        RotationModel Map(Rotation domainModel);
    }
}
