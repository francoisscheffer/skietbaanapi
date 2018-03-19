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
    public class competitionsController : ApiController
    {
        private SkietbaanDatabase db = new SkietbaanDatabase();

        // GET: api/competitions
        public IQueryable<competition> Getcompetitions()
        {
            return db.competitions;
        }

        // GET: api/competitions/5
        [ResponseType(typeof(competition))]
        public async Task<IHttpActionResult> Getcompetition(int id)
        {
            competition competition = await db.competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            return Ok(competition);
        }

        // PUT: api/competitions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcompetition(int id, competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competition.pkid)
            {
                return BadRequest();
            }

            db.Entry(competition).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!competitionExists(id))
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

        // POST: api/competitions
        [ResponseType(typeof(competition))]
        public async Task<IHttpActionResult> Postcompetition(competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.competitions.Add(competition);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = competition.pkid }, competition);
        }

        // DELETE: api/competitions/5
        [ResponseType(typeof(competition))]
        public async Task<IHttpActionResult> Deletecompetition(int id)
        {
            competition competition = await db.competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            db.competitions.Remove(competition);
            await db.SaveChangesAsync();

            return Ok(competition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool competitionExists(int id)
        {
            return db.competitions.Count(e => e.pkid == id) > 0;
        }
    }
}