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
            var firstServe = TestDataProvider.GetRandom(0, 1);
            var domainGame = _business.StartGame(3, teamRotations, firstServe);
            var gameModel = _mapper.Map(domainGame);
            TempData["GameModel"] = gameModel;
            TempData["ThisPointsServer"] = firstServe;
            return View(gameModel);
        }

        [HttpPost]
        public ActionResult Index(int pointWinner)
        {
            var gameModel = (GameModel)TempData["GameModel"];
            var thisPointsServer = (int)TempData["ThisPointsServer"];
            var domainGame = _mapper.Map(gameModel);
            var addPointResult = _business.AddPoint(domainGame, pointWinner, thisPointsServer);
            var nextServer = pointWinner;

            GameModel updatedGameModel;
            if (addPointResult.ResultStatus == STGBusiness.DomainModels.PointResultStatus.EndOfGame)
            {
                updatedGameModel = _mapper.Map(addPointResult.Game);
                return View("GameOver", updatedGameModel);
            }
            else if (addPointResult.ResultStatus == STGBusiness.DomainModels.PointResultStatus.EndOfSet)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = addPointResult.NextServer.Value;
                var updatedDomainGame = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
                updatedGameModel = _mapper.Map(updatedDomainGame);
            }
            else if (addPointResult.ResultStatus == STGBusiness.DomainModels.PointResultStatus.EndOfSetNextDeciding)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = TestDataProvider.GetRandom(0, 1);
                var updatedDomainGame = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
                updatedGameModel = _mapper.Map(updatedDomainGame);
            }
            else
                updatedGameModel = _mapper.Map(addPointResult.Game);
            TempData["GameModel"] = updatedGameModel;
            TempData["ThisPointsServer"] = nextServer;
            return View(updatedGameModel);
        }
    }
}