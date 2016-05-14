using ScoreToGo.Mappers.Interfaces;
using ScoreToGo.ViewModels;
using STG.Business.Logic.Interfaces;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamePlayBusiness _business;

        private readonly IGamePlayModelMapper _mapper;

        public GameController(IGamePlayBusiness business, IGamePlayModelMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
            var firstServe = TestDataProvider.GetRandom(0, 1);
            var Game = _business.StartGame(3, teamRotations, firstServe);
            var gameModel = _mapper.Map(Game.GamePlay);
            TempData["GameModel"] = gameModel;
            TempData["ThisPointsServer"] = firstServe;
            return View(gameModel);
        }

        [HttpPost]
        public ActionResult Index(int pointWinner)
        {
            var gameModel = (GamePlayModel)TempData["GameModel"];
            var thisPointsServer = (int)TempData["ThisPointsServer"];
            var Game = _mapper.Map(gameModel);
            var addPointResult = _business.AddPoint(Game, pointWinner, thisPointsServer);
            var nextServer = pointWinner;

            GamePlayModel updatedGameModel;
            if (addPointResult.ResultStatus == STG.Business.DomainModels.PointResultStatus.EndOfGame)
            {
                updatedGameModel = _mapper.Map(addPointResult.Game);
                return View("GameOver", updatedGameModel);
            }
            else if (addPointResult.ResultStatus == STG.Business.DomainModels.PointResultStatus.EndOfSet)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = addPointResult.NextServer.Value;
                var updatedGame = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
                updatedGameModel = _mapper.Map(updatedGame);
            }
            else if (addPointResult.ResultStatus == STG.Business.DomainModels.PointResultStatus.EndOfSetNextDeciding)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = TestDataProvider.GetRandom(0, 1);
                var updatedGame = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
                updatedGameModel = _mapper.Map(updatedGame);
            }
            else
                updatedGameModel = _mapper.Map(addPointResult.Game);
            TempData["GameModel"] = updatedGameModel;
            TempData["ThisPointsServer"] = nextServer;
            return View(updatedGameModel);
        }
    }
}