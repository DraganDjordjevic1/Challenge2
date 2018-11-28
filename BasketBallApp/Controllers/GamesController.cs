using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasketBallApp.Models;

namespace BasketBallApp.Controllers
{
    public class GamesController : Controller
    {
        private DatabaseEntities4 db = new DatabaseEntities4();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
            //return View(await db.Games.ToListAsync());
        }

        public  ActionResult PreviousGames()
        {
         
            //return View(games.ToList());
            return View(db.Games.Where(F => F.Date < DateTime.Now).ToList());
        }

        public ActionResult UpcomingGames()
        {
            //return View(games.ToList());
            return View(db.Games.Where(F => F.Date > DateTime.Now).ToList());
        }

        public ActionResult ListOfMembers()
        {
           return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Time,Date,Venue")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Time,Date,Venue")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Game game = await db.Games.FindAsync(id);
            db.Games.Remove(game);
            await db.SaveChangesAsync();
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
