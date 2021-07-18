using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RVAS_Kosarka.ViewModels;
using RVAS_Kosarka.Models;

namespace RVAS_Kosarka.Controllers
{
    
    public class ClubsController : Controller
    {
        private ApplicationDbContext _context;

        public ClubsController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Clubs
        [Authorize(Roles = RoleName.AdminOrRegularUser)]
        public ActionResult Index()
        {
            var clubs = _context.Clubs.ToList();
                                  

            if (User.IsInRole(RoleName.AdminUser))
            {
                return View(clubs);
            }

            return View("ReadOnlyIndex", clubs);
        }

        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult New()
        {

            var Club = new Club();


            return View("ClubForm", Club);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult Save(Club club)
        {

            if (!ModelState.IsValid)
            {
                var Club = new Club();

                return View("ClubForm", Club);
            }

            if (club.Id == 0) //ako ubacujemo novog onda je id = 0
            {
                _context.Clubs.Add(club);
            }
            else // menja se postojeci Klub
            {
                var clubInDatabase = _context.Clubs.Single(c => c.Id == club.Id);
                clubInDatabase.Name = club.Name;
                clubInDatabase.Founded = club.Founded;
                clubInDatabase.City = club.City;
                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Clubs");
        }

        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult Delete(int Id)
        {
            
            try
            {
                var club = _context.Clubs.Find(Id);


                _context.Clubs.Remove(club);

                _context.SaveChanges();

                return RedirectToAction("Index", "Clubs");
            }
            catch ( Exception ex)
            {

                
                
                return RedirectToAction("Index", "Clubs");


            }

        }

        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult Edit(int Id)
        {
            var club = _context.Clubs.SingleOrDefault(c => c.Id == Id);
            if (club == null)
            {
                return HttpNotFound();
            }

            
            return View("ClubForm", club);
        }
    }
}