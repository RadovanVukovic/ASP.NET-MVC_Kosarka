using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RVAS_Kosarka.ViewModels;
using RVAS_Kosarka.Models;
using PagedList;


namespace RVAS_Kosarka.Controllers
{
    
    public class ManagersController : Controller
    {
        private ApplicationDbContext _context;

        public ManagersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.AdminOrRegularUser)]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //trenutna vrednost za sortiranje
            ViewBag.CurrentSort = sortOrder;

            //oni cuvaju sledecu vrednost za sortiranje
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.YearsSortParm = sortOrder == "Years" ? "years_desc" : "Years";
            ViewBag.ClubSortParm = sortOrder == "Club" ? "clubs_desc" : "Club";

            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //cuva uneti tekst za search
            ViewBag.Search = searchString;

            var managers = from m in _context.Managers
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                managers = managers.Where(m => m.Name.Contains(searchString)                                       
                                       || m.Club.Name.Contains(searchString));
            }

            
            
            switch (sortOrder)
            {
                case "name_desc":
                    managers = managers.OrderByDescending(s => s.Name);
                    break;
                case "Years":
                    managers = managers.OrderBy(s => s.Years);
                    break;
                case "years_desc":
                    managers = managers.OrderByDescending(s => s.Years);
                    break;
                case "Club":
                    managers = managers.OrderBy(s => s.Club.Name);
                    break;
                case "clubs_desc":
                    managers = managers.OrderByDescending(s => s.Club.Name);
                    break;
                default:
                    managers = managers.OrderBy(s => s.Name);
                    break;
            }


            int pageSize = 5;

            //ako page ima value vrati taj value, ako je null onda je page=1
            int pageNumber = (page ?? 1);
           

            if (User.IsInRole(RoleName.AdminUser))
            {
                return View(managers.ToPagedList(pageNumber, pageSize));
            }

            return View("ReadOnlyIndex", managers.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult New()
        {

            var clubs = _context.Clubs.ToList();
            

            var viewModel = new ManagerFormViewmodel
            {
                Manager = new Manager(),
                Clubs = clubs,
                
            };

            return View("ManagerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult Save(Manager manager)
        {

            if (!ModelState.IsValid)
            {
                var clubs = _context.Clubs.ToList();


                var viewModel = new ManagerFormViewmodel
                {
                    Manager = new Manager(),
                    Clubs = clubs,

                };

                return View("ManagerForm", viewModel);
            }

            var all_managers = _context.Managers.ToList();
            int count = 0;

            foreach(var m in all_managers)
            {
                if(m.Id == manager.Id)
                {
                    count++;
                }
            }

            if (count == 0) //ako ne postoji takav id dodaje se novi menadzer
            {
                _context.Managers.Add(manager);
            }
            else // menja se postojeci Manager
            {
                var managerInDatabase = _context.Managers.Single(m => m.Id == manager.Id);
                managerInDatabase.Name = manager.Name;
                managerInDatabase.Years = manager.Years;
                managerInDatabase.Id = manager.Id;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Managers");
        }

        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult Delete(int Id)
        {

            try
            {
                var manager = _context.Managers.Find(Id);


                _context.Managers.Remove(manager);

                _context.SaveChanges();

                return RedirectToAction("Index", "Managers");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Managers");


            }

        }

        [Authorize(Roles = RoleName.AdminUser)]
        public ActionResult Edit(int Id)
        {
            var manager = _context.Managers.SingleOrDefault(m => m.Id == Id);
            if (manager == null)
            {
                return HttpNotFound();
            }


            var viewModel = new ManagerFormViewmodel
            {
                Manager = manager,
                
                Clubs = _context.Clubs.ToList()

            };

            return View("ManagerForm", viewModel);
        }
    }
}