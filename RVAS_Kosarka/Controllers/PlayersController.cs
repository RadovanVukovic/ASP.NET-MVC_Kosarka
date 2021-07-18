using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RVAS_Kosarka.Models;
using System.Web.Mvc;
using System.Data.Entity;
using RVAS_Kosarka.ViewModels;


namespace RVAS_Kosarka.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext _context;

        public PlayersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var players = _context.Players.Include(p => p.Club).Include(p => p.Position).ToList();

            if(User.IsInRole(RoleName.RegularUser) || User.IsInRole(RoleName.AdminUser))
            {
                return View(players);
            }

            return View("ReadOnlyIndex", players);
        }

        [Authorize(Roles = RoleName.AdminOrRegularUser)]
        public ActionResult New()
        {
            var clubs = _context.Clubs.ToList();
            var positions = _context.Positions.ToList();

            var viewModel = new PlayerFormViewModel
            {
                Player = new Player(),
                Clubs = clubs,
                Positions = positions
            };

            return View("PlayerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminOrRegularUser)]
        public ActionResult Save(Player player)
        {
            
            if (!ModelState.IsValid)
            {
                var clubs = _context.Clubs.ToList();
                var positions = _context.Positions.ToList();

                var viewModel = new PlayerFormViewModel
                {
                    Player = new Player(),
                    Clubs = clubs,
                    Positions = positions
                };

                return View("PlayerForm", viewModel);
            }

            if (player.Id == 0) //ako ubacujemo novog onda je id = 0
            {
                _context.Players.Add(player);
            }
            else // menja se postojeci Player
            {
                var playerInDatabase = _context.Players.Single(c => c.Id == player.Id);
                playerInDatabase.Name = player.Name;
                playerInDatabase.Height = player.Height;
                playerInDatabase.Weight = player.Weight;
                playerInDatabase.Years = player.Years;
                playerInDatabase.PositionId = player.PositionId;
                playerInDatabase.ClubId = player.ClubId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Players");
        }

        [Authorize(Roles = RoleName.AdminOrRegularUser)]
        public ActionResult Delete(int Id)
        {
            
            try
            {
                var player = _context.Players.Find(Id);


                _context.Players.Remove(player);

                _context.SaveChanges();

                return RedirectToAction("Index", "Players");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Players");


            }

        }

        [Authorize(Roles = RoleName.AdminOrRegularUser)]
        public ActionResult Edit(int Id)
        {
            var player = _context.Players.SingleOrDefault(p => p.Id == Id);
            if (player == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PlayerFormViewModel
            {
                Player = player,
                Positions = _context.Positions.ToList(),
                Clubs = _context.Clubs.ToList()
                
            };

            return View("PlayerForm", viewModel);
        }

    }
}