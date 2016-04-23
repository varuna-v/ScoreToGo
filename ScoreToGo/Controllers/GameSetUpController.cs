using ScoreToGo.Models;
using STG.Business.DomainModels;
using STG.Business.Logic.Interfaces;
using STG.Business.Mappers;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameSetUpController : Controller
    {
        private readonly IGameBusiness _business;

        private readonly IModelMapper<GameModel, DomainGame> _mapper;

        public GameSetUpController(IGameBusiness business, IModelMapper<GameModel, DomainGame> mapper)
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
            //var gameModel = _mapper.Map(domainGame);
            //TempData["GameModel"] = gameModel;
            //TempData["ThisPointsServer"] = firstServe;
            //return View(gameModel);
        }
    }
}