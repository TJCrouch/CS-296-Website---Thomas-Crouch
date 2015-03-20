using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeagueOfInfo.DAL;
using LeagueOfInfo.Models;


namespace LeagueOfInfo.Controllers
{
    public class TeamController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Team
        public /*ActionResult*/ViewResult Index(/*string sortOrder, string currentFilter, string searchString, int? page*/)
        {
            var teams = unitOfWork.TeamRepository.Get(includeProperties: "Leagues");
            return View(teams.ToList());
            /*
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "TeamName" : "LeagueName";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var teams = from s in db.Teams
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                teams = teams.Where(s => s.TeamName.Contains(searchString)
                                       || s.LeagueName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "TeamName":
                    teams = teams.OrderByDescending(s => s.TeamName);
                    break;
                case "LeagueName":
                    teams = teams.OrderBy(s => s.LeagueName);
                    break;
                default:
                    teams = teams.OrderBy(s => s.TeamName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(teams.ToPagedList(pageNumber, pageSize));
             */
        }

        // GET: Team/Details/5
        public /*ActionResult*/ViewResult Details(int id)
        {
            Team team = unitOfWork.TeamRepository.GetByID(id);
            return View(team);
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
             */
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            PopulateLeaguesDropDownList();
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,TeamName,LeagueName")] /*TeamViewModel teamVm*/ Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.TeamRepository.Insert(team);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes.  Try again, and if the problem persists, see your system administrator.");
            }
            PopulateLeaguesDropDownList(team.LeagueID);
            return View(team);
            /*
            if (ModelState.IsValid)
            {
                Team team = new Team();
                team.TeamName = teamVm.TeamName;

                var league = (from a in db.Leagues
                             where a.LeagueName == teamVm.LeagueName.Name
                                  select a).FirstOrDefault<League>();
                team.TeamID = team.TeamID;
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamVm);
             */
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            Team team = unitOfWork.TeamRepository.GetByID(id);
            PopulateLeaguesDropDownList(team.LeagueID);
            return View(team);
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
             */
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,LeagueName")] Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.TeamRepository.Update(team);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes.  Try again, and if the problem persists, see your system administrator");
            }
            PopulateLeaguesDropDownList(team.LeagueID);
            return View(team);
            /*
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
             */
        }

        private void PopulateLeaguesDropDownList(object selectedLeague = null)
        {
            var leaguesQuery = unitOfWork.LeagueRepository.Get(orderBy: q => q.OrderBy(d => d.LeagueName));
            ViewBag.LeagueID = new SelectList(leaguesQuery, "LeagueID", "LeagueName", selectedLeague);
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            Team team = unitOfWork.TeamRepository.GetByID(id);
            return View(team);
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
             */
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = unitOfWork.TeamRepository.GetByID(id);
            unitOfWork.TeamRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
            /*
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
             */
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
            /*
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
             * */
        }
    }
}
