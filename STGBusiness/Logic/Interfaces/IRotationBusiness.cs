using STG.Business.DomainModels;

namespace STG.Business.Logic.Interfaces
{
    public interface IRotationBusiness
    {
        Rotation Rotate(Rotation model, int pointWinner);
    }
}
