using STGBusiness.Enums;
using STGBusiness.Logic;
using STGBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class RotationController : Controller
    {
        private RotationBusiness _business;

        public RotationController()
        {
            _business = new RotationBusiness();
        }

        public ActionResult Index()
        {
            var initialRotationModel = new RotationModel();
            initialRotationModel.TeamRotations = new TeamRotationModel[2];
            initialRotationModel.TeamRotations[0] = new TeamRotationModel()
            {
                ShirtNumbers = new int[] { 5, 12, 6, 7, 10, 1 },
                TeamLabel = STGBusiness.Enums.TeamLabel.TeamA
            };
            initialRotationModel.TeamRotations[1] = new TeamRotationModel()
            {
                ShirtNumbers = new int[] { 13, 9, 2, 10, 12, 4 },
                TeamLabel = STGBusiness.Enums.TeamLabel.TeamB
            };
            return View(initialRotationModel);
        }

        [HttpPost]
        public ActionResult Index(RotationModel model, TeamLabel pointWinner)
        {
            ModelState.Clear();
            var rotatedModel = _business.Rotate(model, pointWinner);
            return View(rotatedModel);
        }
    }
}