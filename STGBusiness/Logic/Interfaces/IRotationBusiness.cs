using STG.Business.DomainModels;

namespace STG.Business.Logic.Interfaces
{
    public interface IRotationBusiness
    {
        DomainRotation Rotate(DomainRotation model, int pointWinner);
    }
}
