using ScoreToGo.Models;
using STG.Business.DomainModels;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IRotationModelMapper
    {
        DomainRotation Map(RotationModel rotationModel);
        RotationModel Map(DomainRotation domainModel);
    }
}
