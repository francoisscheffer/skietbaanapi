using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using skietbaanAPIAndScoreSite.Models;

namespace skietbaanAPIAndScoreSite.Controllers
{
    public class shootersController : ApiController
    {
        private SkietbaanDatabase db = new SkietbaanDatabase();

        // GET: api/shooters
        public IQueryable<shooter> Getshooters()
        {
            return db.shooters;
        }

        // GET: api/shooters/5
        [ResponseType(typeof(shooter))]
        public async Task<IHttpActionResult> Getshooter(int id)
        {
            shooter shooter = await db.shooters.FindAsync(id);
            if (shooter == null)
            {
                return NotFound();
            }

            return Ok(shooter);
        }

        // PUT: api/shooters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putshooter(int id, shooter shooter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shooter.pkid)
            {
                return BadRequest();
            }

            db.Entry(shooter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!shooterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/shooters
        [ResponseType(typeof(shooter))]
        public async Task<IHttpActionResult> Postshooter(shooter shooter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.shooters.Add(shooter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shooter.pkid }, shooter);
        }

        // DELETE: api/shooters/5
        [ResponseType(typeof(shooter))]
        public async Task<IHttpActionResult> Deleteshooter(int id)
        {
            shooter shooter = await db.shooters.FindAsync(id);
            if (shooter == null)
            {
                return NotFound();
            }

            db.shooters.Remove(shooter);
            await db.SaveChangesAsync();

            return Ok(shooter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool shooterExists(int id)
        {
            return db.shooters.Count(e => e.pkid == id) > 0;
        }
    }
}