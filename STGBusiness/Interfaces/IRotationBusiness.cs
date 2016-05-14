using STG.Domain.Models;

namespace STG.Business.Interfaces
{
    public interface IRotationBusiness
    {
        Rotation Rotate(Rotation model, int pointWinner);
    }
}
