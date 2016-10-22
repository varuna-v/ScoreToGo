using ScoreToGo.ViewModels;
using STG.Business.Interfaces;
using STG.Domain.Mappers;
using STG.Domain.Models;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class RotationController : Controller
    {
        private readonly IRotationBusiness _business;

        private readonly IMapper _mapper;

        public RotationController(IRotationBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var initialRotationModel = new Rotation();
            initialRotationModel.TeamRotations = new TeamRotation[2];
            initialRotationModel.TeamRotations[0] = new TeamRotation()
            {
                ShirtNumbers = new int[] { 5, 12, 6, 7, 10, 1 }
            };
            initialRotationModel.TeamRotations[1] = new TeamRotation()
            {
                ShirtNumbers = new int[] { 13, 9, 2, 10, 12, 4 }
            };
            return View(initialRotationModel);
        }

        [HttpPost]
        public ActionResult Index(Rotation model, int pointWinner)
        {
            ModelState.Clear();
            var rotatedModel = _business.Rotate(model, pointWinner);
            return View(rotatedModel);
        }
    }
}