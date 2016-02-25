using ScoreToGo.Mappers.Interfaces;
using ScoreToGo.Models;
using STGBusiness.Logic.Interfaces;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameBusiness _business;

        private readonly IGameModelMapper _mapper;

        public GameController(IGameBusiness business, IGameModelMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
            var domainGame = _business.StartGame(5);
            domainGame = _business.StartNewSet(domainGame, teamRotations);
            var gameModel = _mapper.Map(domainGame);
            TempData["GameModel"] = gameModel;
            return View(gameModel);
        }

        [HttpPost]
        public ActionResult Index(int pointWinner)
        {
            var gameModel = (GameModel)TempData["GameModel"];
            var domainGame = _mapper.Map(gameModel);
            var addPointResult = _business.AddPoint(domainGame, pointWinner);

            GameModel updatedGameModel;
            if (addPointResult.ResultStatus == STGBusiness.DomainModels.PointResultStatus.EndOfGame)
            {
                updatedGameModel = _mapper.Map(addPointResult.Game);
                //!! go to different view (with score sheet?)
            }
            else if (addPointResult.ResultStatus == STGBusiness.DomainModels.PointResultStatus.EndOfSet)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                var updatedDomainGame = _business.StartNewSet(addPointResult.Game, teamRotations);
                updatedGameModel = _mapper.Map(updatedDomainGame);
            }
            else
                updatedGameModel = _mapper.Map(addPointResult.Game);
            TempData["GameModel"] = updatedGameModel;
            return View(updatedGameModel);
        }
    }
}