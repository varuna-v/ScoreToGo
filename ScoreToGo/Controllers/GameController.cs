using ScoreToGo.ViewModels;
using STG.Business.Interfaces;
using STG.Domain.Mappers;
using STG.Domain.Models;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamePlayBusiness _business;

        private readonly IMapper _mapper;

        public GameController(IGamePlayBusiness business, IMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
            var firstServe = TestDataProvider.GetRandom(0, 1);
            var game = _business.StartGame(3, teamRotations, firstServe);
            var gameModel = _mapper.Map<GamePlay, GamePlayModel>(game.GamePlay);
            TempData["GameModel"] = gameModel;
            TempData["ThisPointsServer"] = firstServe;
            return View(gameModel);
        }

        //!!change to ajax call instead of post back?
        [HttpPost]
        public ActionResult Index(int pointWinner)
        {
            var gameModel = (GamePlayModel)TempData["GameModel"];
            var thisPointsServer = (int)TempData["ThisPointsServer"];
            var game = _mapper.Map<GamePlayModel, GamePlay>(gameModel);
            var addPointResult = _business.AddPoint(game, pointWinner, thisPointsServer);
            var nextServer = pointWinner;

            GamePlayModel updatedGameModel;
            if (addPointResult.ResultStatus == PointResultStatus.EndOfGame)
            {
                updatedGameModel = _mapper.Map<GamePlay, GamePlayModel>(addPointResult.Game);
                return View("GameOver", updatedGameModel);
            }
            else if (addPointResult.ResultStatus == PointResultStatus.EndOfSet)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = addPointResult.NextServer.Value;
                var updatedGame = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
                updatedGameModel = _mapper.Map<GamePlay, GamePlayModel>(updatedGame);
            }
            else if (addPointResult.ResultStatus == PointResultStatus.EndOfSetNextDeciding)
            {
                var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = TestDataProvider.GetRandom(0, 1);
                var updatedGame = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
                updatedGameModel = _mapper.Map<GamePlay, GamePlayModel>(updatedGame);
            }
            else
                updatedGameModel = _mapper.Map<GamePlay, GamePlayModel>(addPointResult.Game);
            TempData["GameModel"] = updatedGameModel;
            TempData["ThisPointsServer"] = nextServer;
            return View(updatedGameModel);
        }

        
    }
}