using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScoreToGo.Models;
using STG.Business.DomainModels;
using ScoreToGo.Mappers.Interfaces;

namespace ScoreToGo.Mappers
{
    public class RotationModelMapper : IRotationModelMapper
    {
        //!! fast mapper?
        public DomainRotation Map(RotationModel rotationModel)
        {
            var domainModel = new DomainRotation();

            domainModel.TeamRotations = new DomainTeamRotation[2];

            domainModel.TeamRotations[0] = new DomainTeamRotation();
            domainModel.TeamRotations[0].ShirtNumbers = rotationModel.TeamRotations[0].ShirtNumbers;

            domainModel.TeamRotations[1] = new DomainTeamRotation();
            domainModel.TeamRotations[1].ShirtNumbers = rotationModel.TeamRotations[1].ShirtNumbers;

            return domainModel;
        }

        public RotationModel Map(DomainRotation domainModel)
        {
            var model = new RotationModel();

            model.TeamRotations = new TeamRotationModel[2];

            model.TeamRotations[0] = new TeamRotationModel();
            model.TeamRotations[0].ShirtNumbers = domainModel.TeamRotations[0].ShirtNumbers;

            model.TeamRotations[1] = new TeamRotationModel();
            model.TeamRotations[1].ShirtNumbers = domainModel.TeamRotations[1].ShirtNumbers;

            return model;
        }

    }
}