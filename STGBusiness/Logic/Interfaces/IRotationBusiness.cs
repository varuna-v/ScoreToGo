using STGBusiness.DomainModels;

namespace STGBusiness.Logic.Interfaces
{
    public interface IRotationBusiness
    {
        Rotation Rotate(Rotation model, int pointWinner);
    }
}
