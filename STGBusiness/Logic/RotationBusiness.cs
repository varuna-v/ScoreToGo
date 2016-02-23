using STGBusiness.Enums;
using STGBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGBusiness.Logic
{
    public class RotationBusiness
    {
        public RotationModel Rotate(RotationModel model, TeamLabel pointWinner)
        {
            if (model == null || model.TeamRotations == null || model.TeamRotations.Length != 2)
                throw new ArgumentException("Invalid rotation model");
            
            if (model.TeamRotations[0].TeamLabel == pointWinner)
                model.TeamRotations[0] = Rotate(model.TeamRotations[0]);
            else
                model.TeamRotations[1] = Rotate(model.TeamRotations[1]);
           
            return model;
        }

        private TeamRotationModel Rotate(TeamRotationModel model)
        {
            if (model == null || model.ShirtNumbers == null || model.ShirtNumbers.Length != 6)
                throw new ArgumentException("Invalid team rotation model");
           
            TeamRotationModel rotatedModel = new TeamRotationModel();
            rotatedModel.ShirtNumbers = new int[6];
            rotatedModel.ShirtNumbers[0] = model.ShirtNumbers[1];
            rotatedModel.ShirtNumbers[1] = model.ShirtNumbers[2];
            rotatedModel.ShirtNumbers[2] = model.ShirtNumbers[3];
            rotatedModel.ShirtNumbers[3] = model.ShirtNumbers[4];
            rotatedModel.ShirtNumbers[4] = model.ShirtNumbers[5];
            rotatedModel.ShirtNumbers[5] = model.ShirtNumbers[0];
            rotatedModel.TeamLabel = model.TeamLabel;
            return rotatedModel;
        }

    }
}
