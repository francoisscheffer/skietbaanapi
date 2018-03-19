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
    public class vw_shootController : ApiController
    {
        private SkietbaanDatabase db = new SkietbaanDatabase();

        // GET: api/vw_shoot
        public IQueryable<vw_shoot> Getvw_shoot()
        {
            DateTime dt = DateTime.Now.AddMonths(-1);

            //Check if any dataexisit to start
            var cnt = db.vw_shoot.Where(c => c.entrydate > dt).Count();
            if(cnt>0)
            return db.vw_shoot.Where(c => c.entrydate > dt).OrderByDescending(c => c.entrydate).Take(60);
            else return db.vw_shoot.OrderByDescending(c => c.entrydate).Take(60);
        }
        [HttpGet]
        [Route("api/ShootOverview")]
        public IEnumerable<dynamic> ShootOverview()
        {

            DateTime td = DateTime.Now.AddMonths(-1);
           
            var res = (from c in db.vw_shoot
                       select new { Date = c.entrydate, Competition = c.Competition, Name = c.name + ' ' + c.surname, Score = c.score, AvgMonthlyScore = c.compavg, MonthBest = c.monthlybestscore, YealyScore = c.yearlytop4score, Month = c.C_month }).Where(c => c.Date > td).OrderByDescending(c => c.Date).Take(60).ToList();



            return res;
        }


        [HttpGet]
        [Route("api/ShootOverview")]
        public IEnumerable<dynamic> ShootOverview(int comp, bool currentyear)
        {


            int year = DateTime.Now.Year;
            if (!currentyear) year--;
        
            var res = (from c in db.vw_shoot
                       where c.fkcompetition == comp && c.C_year == year
                       select new ShootOVerviewClass {Date = c.entrydate, Competition = c.Competition, Name = c.name +  " " + c.surname, Score = c.score, AvgMonthlyScore = c.compavg, MonthBest = c.monthlybestscore, YealyScore = c.yearlytop4score, Month = c.C_month }).OrderByDescending(c => c.Date).Take(60).ToList();


            return res;
        }
        // GET: api/vw_shoot/5
        [ResponseType(typeof(vw_shoot))]
        public async Task<IHttpActionResult> Getvw_shoot(int id)
        {
            vw_shoot vw_shoot = await db.vw_shoot.FindAsync(id);
            if (vw_shoot == null)
            {
                return NotFound();
            }

            return Ok(vw_shoot);
        }
        [HttpGet]
        [Route("api/ShootOverviewYearly")]
        public IEnumerable<dynamic> ShootOverviewYearly(int comp, bool currentyear)
        {

            int? year = DateTime.Now.Year;
            if (!currentyear) year--;

            //  var contex = new SkietbaanDataContexDataContext();
            var res = (from c in db.vw_yearlyrating
                       where c.fkcompetition == comp && c.C_year == year
                       //select new { Competition= c.Competition, Name = c.name + ' ' + c.surname,Position= c.yearlyposition,Score=c.yearlyscore,Best=c.yearsbest }).OrderBy(c => c.Position).Take(60);
                       select new { Competition = c.Competition, fkCompetition = c.fkcompetition, Name = c.name + " " + c.surname, Position = 1, Score = c.yearlytop4score, msisdn = c.msisdn, year = year }).ToList();
                       //select c).ToList();

           List < ShootOverviewYearlyClass > returnlist = new List<ShootOverviewYearlyClass>();
            //get each persons position for the year
            foreach (var item in res)
            {

                ShootOverviewYearlyClass newItem = new ShootOverviewYearlyClass();
                newItem = new ShootOverviewYearlyClass { Competition = item.Competition, Name = item.Name, Score = item.Score, Year = item.year ?? 0 };

                var ranking = (from c in db.vw_yearlyrating where c.C_year == year && c.fkcompetition == item.fkCompetition && c.yearlytop4score > item.Score && c.msisdn != item.msisdn select c).Count() + 1;
                newItem.Position = ranking;
                returnlist.Add(newItem);
            }

            return returnlist.OrderBy(c => c.Position);
            
        }
        public class ShootOverviewYearlyClass
        {

            public string Competition { get; set; }
            public string Name { get; set; }
            public int Position { get; set; }
            public decimal? Score { get; set; }
            public int Year { get; set; }
        }
        // GET: api/Shoot/5
        // PUT: api/vw_shoot/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putvw_shoot(int id, vw_shoot vw_shoot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vw_shoot.ShooterId)
            {
                return BadRequest();
            }

            db.Entry(vw_shoot).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_shootExists(id))
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

        // POST: api/vw_shoot
        [ResponseType(typeof(vw_shoot))]
        public async Task<IHttpActionResult> Postvw_shoot(vw_shoot vw_shoot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vw_shoot.Add(vw_shoot);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (vw_shootExists(vw_shoot.ShooterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vw_shoot.ShooterId }, vw_shoot);
        }

        // DELETE: api/vw_shoot/5
        [ResponseType(typeof(vw_shoot))]
        public async Task<IHttpActionResult> Deletevw_shoot(int id)
        {
            vw_shoot vw_shoot = await db.vw_shoot.FindAsync(id);
            if (vw_shoot == null)
            {
                return NotFound();
            }

            db.vw_shoot.Remove(vw_shoot);
            await db.SaveChangesAsync();

            return Ok(vw_shoot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vw_shootExists(int id)
        {
            return db.vw_shoot.Count(e => e.ShooterId == id) > 0;
        }
    }
}