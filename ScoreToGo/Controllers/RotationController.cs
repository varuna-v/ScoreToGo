using STGBusiness.Logic;
using ScoreToGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreToGo.Mappers;

namespace ScoreToGo.Controllers
{
    public class RotationController : Controller
    {
        private readonly RotationBusiness _business;

        private readonly RotationModelMapper _mapper;

        public RotationController()
        {
            _business = new RotationBusiness();
            _mapper = new RotationModelMapper();
        }

        public ActionResult Index()
        {
            var initialRotationModel = new RotationModel();
            initialRotationModel.TeamRotations = new TeamRotationModel[2];
            initialRotationModel.TeamRotations[0] = new TeamRotationModel()
            {
                ShirtNumbers = new int[] { 5, 12, 6, 7, 10, 1 }
            };
            initialRotationModel.TeamRotations[1] = new TeamRotationModel()
            {
                ShirtNumbers = new int[] { 13, 9, 2, 10, 12, 4 }
            };
            return View(initialRotationModel);
        }

        [HttpPost]
        public ActionResult Index(RotationModel model, int pointWinner)
        {
            ModelState.Clear();
            var domainModel = _mapper.Map(model);
            var rotatedDomainModel = _business.Rotate(domainModel, pointWinner);
            var rotatedModel = _mapper.Map(rotatedDomainModel);
            return View(rotatedModel);
        }
    }
}