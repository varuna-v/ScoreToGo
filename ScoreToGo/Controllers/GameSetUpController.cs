using ScoreToGo.ViewModels;
using STG.Business.Logic.Interfaces;
using STG.Domain.Mappers;
using STG.Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameSetUpController : Controller
    {
        private readonly IGameBusiness _business;

        private readonly ITeamBusiness _teamBusiness;

        private readonly IMapper _mapper;

        public GameSetUpController(IGameBusiness business, ITeamBusiness teamBusiness, IMapper mapper)
        {
            _business = business;
            _teamBusiness = teamBusiness;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var Game = _business.GetInitialGame();
            var model = _mapper.Map<Game, GameModel>(Game);
            var availableTeams = _teamBusiness.GetAllTeams();
            model.AvailableTeams = _mapper.Map<List<Team>, List<TeamModel>>(availableTeams);
            return View(model);
            //var teamRotations = TestDataProvider.GetRandomTeamRotationModels();
            //var firstServe = TestDataProvider.GetRandom(0, 1);
            //var Game = _business.StartGame(3, teamRotations, firstServe);
            //var gameModel = _mapper.Map<Game, GameModel>(Game);
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