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
    public class ChampionController : Controller
    {
        private LeagueOfInfoContext db = new LeagueOfInfoContext();

        // GET: Champion
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ChampionName" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var champions = from s in db.Champions
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                champions = champions.Where(s => s.ChampionName.Contains(searchString)
                                       || s.RoleName.Contains(searchString)
                                       || s.PrimaryAttribute.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ChampionName":
                    champions = champions.OrderByDescending(s => s.ChampionName);
                    break;
                case "RoleName":
                    champions = champions.OrderBy(s => s.RoleName);
                    break;
                case "name2":
                    champions = champions.OrderBy(s => s.PrimaryAttribute);
                    break;
                default:
                    champions = champions.OrderBy(s => s.ChampionName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(champions.ToPagedList(pageNumber, pageSize));
        }

        // GET: Champion/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Champion champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // GET: Champion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Champion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChampionID,RoleName,PrimaryAttribute")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                db.Champions.Add(champion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(champion);
        }

        // GET: Champion/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Champion champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // POST: Champion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChampionID,RoleName,PrimaryAttribute")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(champion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(champion);
        }

        // GET: Champion/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Champion champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // POST: Champion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Champion champion = db.Champions.Find(id);
            db.Champions.Remove(champion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
