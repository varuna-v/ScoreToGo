using ScoreToGo.Mappers.Interfaces;
using ScoreToGo.ViewModels;
using STG.Business.Logic.Interfaces;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class RotationController : Controller
    {
        private readonly IRotationBusiness _business;

        private readonly IRotationModelMapper _mapper;

        public RotationController(IRotationBusiness business, IRotationModelMapper mapper)
        {
            _business = business;
            _mapper = mapper;
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