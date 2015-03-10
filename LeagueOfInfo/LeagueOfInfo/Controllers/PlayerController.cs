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
using PagedList;

namespace LeagueOfInfo.Controllers
{
    public class PlayerController : Controller
    {
        //private LeagueOfInfoContext db = new LeagueOfInfoContext();

        private IPlayerRepository playerRepository;

        public PlayerController()
        {
            this.playerRepository = new PlayerRepository(new LeagueOfInfoContext());
        }

        // GET: Player
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "PlayerName" : "";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var players = from s in playerRepository.GetPlayers()
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.PlayerName.Contains(searchString)
                                       || s.TeamName.Contains(searchString)
                                       || s.LeagueName.Contains(searchString)
                                       || s.RoleName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "PlayerName":
                    players = players.OrderBy(s => s.PlayerName);
                    break;
                case "TeamName":
                    players = players.OrderByDescending(s => s.TeamName);
                    break;
                case "LeagueName":
                    players = players.OrderBy(s => s.LeagueName);
                    break;
                case "RoleName":
                    players = players.OrderBy(s => s.RoleName);
                    break;
                default:
                    players = players.OrderBy(s => s.PlayerName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            Player player = playerRepository.GetPlayerByID(id);
            
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            // Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
            
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,TeamName,LeagueName,RoleName")] Player player)
        {
            /*
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
             */

            try
            {
                if (ModelState.IsValid)
                {
                    playerRepository.InsertPlayer(player);
                    playerRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Player player = playerRepository.GetPlayerByID(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,TeamName,LeagueName,RoleName")] Player player)
        {
            if (ModelState.IsValid)
            {
                playerRepository.UpdatePlayer(player);
                playerRepository.Save();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Player player = playerRepository.GetPlayerByID(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = playerRepository.GetPlayerByID(id);
            playerRepository.DeletePlayer(id);
            playerRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            playerRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
