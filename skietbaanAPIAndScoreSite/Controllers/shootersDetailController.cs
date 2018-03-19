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
    public class shootersDetailController : Controller
    {
        private SkietbaanDatabase db = new SkietbaanDatabase();

        // GET: shootersDetail
        public async Task<ActionResult> Index()
        {
            return View(await db.shooters.ToListAsync());
        }

        // GET: shootersDetail/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shooter shooter = await db.shooters.FindAsync(id);
            if (shooter == null)
            {
                return HttpNotFound();
            }
            return View(shooter);
        }

        // GET: shootersDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: shootersDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pkid,msisdn,name,surname,bmember,pws")] shooter shooter)
        {
            if (ModelState.IsValid)
            {
                db.shooters.Add(shooter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(shooter);
        }

        // GET: shootersDetail/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shooter shooter = await db.shooters.FindAsync(id);
            if (shooter == null)
            {
                return HttpNotFound();
            }
            return View(shooter);
        }

        // POST: shootersDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pkid,msisdn,name,surname,bmember,pws")] shooter shooter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shooter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shooter);
        }

        // GET: shootersDetail/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shooter shooter = await db.shooters.FindAsync(id);
            if (shooter == null)
            {
                return HttpNotFound();
            }
            return View(shooter);
        }

        // POST: shootersDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            shooter shooter = await db.shooters.FindAsync(id);
            db.shooters.Remove(shooter);
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
