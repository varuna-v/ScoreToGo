using ScoreToGo.Models;
using STG.Business.Logic.Interfaces;
using STG.Business.Mappers;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameSetUpController : Controller
    {
        private readonly IGamePlayBusiness _business;

        private readonly IMapper _mapper;

        public GameSetUpController(IGamePlayBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View(new GameModel());
            //var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
            //var firstServe = TestDataProvider.GetRandom(0, 1);
            //var domainGame = _business.StartGame(3, teamRotations, firstServe);
            //var gameModel = _mapper.Map<DomainGame, GameModel>(domainGame);
            //TempData["GameModel"] = gameModel;
            //TempData["ThisPointsServer"] = firstServe;
            //return View(gameModel);
        }

        [HttpPost]
        public ActionResult Index(GameModel model)
        {
            return View(model);
        }
    }
}