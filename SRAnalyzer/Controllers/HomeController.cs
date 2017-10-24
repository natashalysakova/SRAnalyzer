using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SRAnalyzer.Models;
using SRAnalyzer.Models.ScoreItemsModels;
using SRAnalyzerLibrary;
using SRAnalyzerLibrary.Repositories;

namespace SRAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unit;

        public HomeController(IRepository<Player> playerRepository, IRepository<ScoreItem> scoreRepository)
        {
            unit = new UnitOfWork(playerRepository, scoreRepository);
        }

        public IActionResult Index()
        {
            MainPageViewModel model = unit.GetMainPageView();

            return View(model);
        }

        public IActionResult AddScores()
        {
            ViewBag.PlayersList = unit.GetPlayersSelectList();
            return View("AddScoresView");
        }

        [HttpPost]
        public IActionResult AddScores(AddBatchScoreModel model)
        {
            if (model.PlayerId != 0)
            {
                unit.AddBatchOfScores(model);
            }

            return RedirectToAction("Index");
        }
    }
}
