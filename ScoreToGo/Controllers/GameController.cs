using ScoreToGo.ViewModels;
using STG.Business.Interfaces;
using STG.Domain.Models;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameController : Controller
    {
        private readonly IGamePlayBusiness _business;

        public GameController(IGamePlayBusiness business)
        {
            _business = business;
        }

        public ActionResult Index()
        {
            TeamRotation[] teamRotations = TestDataProvider.GetRandomTeamRotationModels();
            int firstServe = TestDataProvider.GetRandom(0, 1);
            Game game = _business.StartGame(3, teamRotations, firstServe);
            game.GamePlay.CurrentServer = firstServe;
            return View(new GamePlayViewModel(game.GamePlay));
        }

        [HttpPost]
        public JsonResult AddPoint(GamePlayViewModel gameModel, int pointWinner)
        {
            int thisPointsServer = gameModel.GamePlay.CurrentServer;
            AddPointResult addPointResult = _business.AddPoint(gameModel.GamePlay, pointWinner, thisPointsServer);
            int nextServer = pointWinner;

            GamePlay updatedGameModel;
            if (addPointResult.ResultStatus == PointResultStatus.EndOfGame)
            {
                addPointResult.Game.GameOver = true;
                return Json(addPointResult.Game);
            }
            else if (addPointResult.ResultStatus == PointResultStatus.EndOfSet)
            {
                TeamRotation[] teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = addPointResult.NextServer.Value;
                updatedGameModel = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
            }
            else if (addPointResult.ResultStatus == PointResultStatus.EndOfSetNextDeciding)
            {
                TeamRotation[] teamRotations = TestDataProvider.GetRandomTeamRotationModels();
                nextServer = TestDataProvider.GetRandom(0, 1);
                updatedGameModel = _business.StartNewSet(addPointResult.Game, teamRotations, nextServer);
            }
            else
                updatedGameModel = addPointResult.Game;
            updatedGameModel.CurrentServer = nextServer;
            return Json(new GamePlayViewModel(updatedGameModel));
        }

        [HttpPost]
        public JsonResult Substitute(GamePlayViewModel gameModel, int team, int shirtNumberGoingIn, int shirtNumberComingOut)
        {
            _business.Substitute(gameModel.GamePlay, team, shirtNumberGoingIn, shirtNumberComingOut); //!! use returned value
            return Json(new GamePlayViewModel(gameModel.GamePlay));
        }

        [HttpPost]
        public JsonResult LogTimeOut(GamePlayViewModel gameModel, int team)
        {
            GameUpdateResult updateResult = _business.LogTimeOut(gameModel.GamePlay, team); 
            GamePlayViewModel viewModel = new GamePlayViewModel(gameModel.GamePlay);
            viewModel.GameUpdateResult = updateResult;
            return Json(viewModel);
        }

        public ActionResult GameOver()
        {
            return View(new ViewModels.GameModel { GamePlay = new GamePlayViewModel(new GamePlay { SetWins = new int[] { 1, 2 } }) }); //!! hardcoded results
        }

    }
}