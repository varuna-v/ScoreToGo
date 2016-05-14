using STG.Domain.Models;
using STG.Business.Interfaces;
using System;

namespace STG.Business
{
    public class RotationBusiness : IRotationBusiness
    {
        public Rotation Rotate(Rotation model, int pointWinner)
        {            
            model.TeamRotations[pointWinner] = Rotate(model.TeamRotations[pointWinner]);           
            return model;
        }

        private TeamRotation Rotate(TeamRotation model)
        {
            if (model == null || model.ShirtNumbers == null || model.ShirtNumbers.Length != 6)
                throw new ArgumentException("Invalid team rotation model");
           
            TeamRotation rotatedModel = new TeamRotation();
            rotatedModel.ShirtNumbers = new int[6];
            rotatedModel.ShirtNumbers[0] = model.ShirtNumbers[1];
            rotatedModel.ShirtNumbers[1] = model.ShirtNumbers[2];
            rotatedModel.ShirtNumbers[2] = model.ShirtNumbers[3];
            rotatedModel.ShirtNumbers[3] = model.ShirtNumbers[4];
            rotatedModel.ShirtNumbers[4] = model.ShirtNumbers[5];
            rotatedModel.ShirtNumbers[5] = model.ShirtNumbers[0];
            return rotatedModel;
        }

    }
}
