using ScoreToGo.ViewModels;
using STG.Business.Interfaces;
using STG.Domain.Models;
using System;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class GameStatsController : Controller
    {
        private readonly IGamePlayBusiness _business;

        private readonly IGameStatsBusiness _statsBusiness;

        public GameStatsController(IGamePlayBusiness business, IGameStatsBusiness statsBusiness)
        {
            _business = business;
            _statsBusiness = statsBusiness;
        }

        public ActionResult Index(Guid gameId)
        {
            Game game = _business.GetGame(gameId);
            GameStats stats = _statsBusiness.GetGameStats(game);
            return View(new GameStatsViewModel(stats));
        }
    }
}