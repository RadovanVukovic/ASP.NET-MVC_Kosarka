using RVAS_Kosarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RVAS_Kosarka.Controllers
{
    [Authorize(Roles = RoleName.AdminOrRegularUser)]
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Games
        public ActionResult Index()
        {
            var games = _context.Games.ToList();


            return View(games);
        }

        public ActionResult Show(int id)
        {
            var game = _context.Games.Find(id);

            var box_scores = game.BoxScores;

            

            return View("BoxScore", box_scores);
        }
    }
}