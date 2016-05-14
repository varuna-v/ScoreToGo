using ScoreToGo.ViewModels;
using STG.Business.DomainModels;
using STG.Domain.Models;

namespace ScoreToGo.Mappers.Interfaces
{
    public interface IRotationModelMapper
    {
        Rotation Map(RotationModel rotationModel);
        RotationModel Map(Rotation domainModel);
    }
}
