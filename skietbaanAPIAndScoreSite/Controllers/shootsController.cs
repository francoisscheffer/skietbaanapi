using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using skietbaanAPIAndScoreSite.Models;

namespace skietbaanAPIAndScoreSite.Controllers
{
    public class shootsController : Controller
    {
        private SkietbaanDatabase db = new SkietbaanDatabase();

        // GET: shoots
        public async Task<ActionResult> Index()
        {
            var shoots = db.shoots;//.Include(s => s.competition);
            return View(await shoots.ToListAsync());
        }

        // GET: shoots/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shoot shoot = await db.shoots.FindAsync(id);
            if (shoot == null)
            {
                return HttpNotFound();
            }
            return View(shoot);
        }

        // GET: shoots/Create
        public ActionResult Create()
        {
            ViewBag.fkcompetition = new SelectList(db.competitions, "pkid", "description");
            return View();
        }

        // POST: shoots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pkid,msisdn,entrydate,fkcompetition,score,C_month,compavg,C_year,yearlytop4score,monthlybestscore")] shoot shoot)
        {
            decimal? top4score = 0;
            decimal? avgscore = 0;
            decimal monthbest = 0;

            if (ModelState.IsValid)
            {
                //First add entry
                db.shoots.Add(shoot);
                await db.SaveChangesAsync();

                //get teh object to update
                var shootObject = (from c in db.shoots where c.pkid == shoot.pkid select c).FirstOrDefault();

                //Before we can save the user we need to calc the avg score
                var res = (from c in db.shoots where c.msisdn == shoot.msisdn && c.fkcompetition == shoot.fkcompetition
                          && c.C_year==shoot.C_year select c);
                if (res.Count() > 0)
                {
                    //get the top 4 skores
                   decimal scores = res.OrderByDescending(c => c.score).Take(4).Sum(c=>c.score)??1;
                    decimal avg = res.OrderByDescending(c => c.score).Sum(c => c.score) ?? 1;
                    
                    var topmonthscores =( res.Where(c=>c.C_month== shoot.entrydate.Value.Month) .
                        OrderByDescending(c => c.score).Take(1).Select(c=>c.score)).FirstOrDefault();

                    monthbest = topmonthscores??0;
                    top4score = Convert.ToDecimal( scores / 4);

                    avgscore = avg / res.Count();
                }
                else {

                    shoot.monthlybestscore = shoot.score;
                    shoot.compavg = (double) shoot.score;
                }

                shoot.yearlytop4score = top4score;
                shoot.compavg = (double)avgscore;
                shoot.monthlybestscore = monthbest;

                //Update shoot
                shootObject.yearlytop4score = top4score;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.fkcompetition = new SelectList(db.competitions, "pkid", "description", shoot.fkcompetition);
            return View(shoot);
        }

        // GET: shoots/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shoot shoot = await db.shoots.FindAsync(id);
            if (shoot == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkcompetition = new SelectList(db.competitions, "pkid", "description", shoot.fkcompetition);
            return View(shoot);
        }

        // POST: shoots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pkid,msisdn,entrydate,fkcompetition,score,C_month,compavg,C_year,yearlytop4score,monthlybestscore")] shoot shoot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.fkcompetition = new SelectList(db.competitions, "pkid", "description", shoot.fkcompetition);
            return View(shoot);
        }

        // GET: shoots/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shoot shoot = await db.shoots.FindAsync(id);
            if (shoot == null)
            {
                return HttpNotFound();
            }
            return View(shoot);
        }

        // POST: shoots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            shoot shoot = await db.shoots.FindAsync(id);
            db.shoots.Remove(shoot);
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
