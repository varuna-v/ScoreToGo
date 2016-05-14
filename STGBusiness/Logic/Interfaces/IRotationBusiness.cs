using STG.Domain.Models;

namespace STG.Business.Logic.Interfaces
{
    public interface IRotationBusiness
    {
        Rotation Rotate(Rotation model, int pointWinner);
    }
}
