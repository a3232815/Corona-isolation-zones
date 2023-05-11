using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using שרת_שנה_ג.ef;
using שרת_שנה_ג.Models;

namespace שרת_שנה_ג.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE")]
    public class StatisticsController : ApiController
    {
        // GET: api/Statistics
        public int Get()
        {
            return DB_statictics.AmountNotVaccinated();
        }

        // GET: api/Statistics/5
        public IEnumerable<object> Get(int id)
        {
            //return DB_statictics.AmountpatientsAllDay();
            using (Corona_DBEntities db = new Corona_DBEntities())
            {
                //System.DateTime now = DateTime.Today;
                //var resulte = db.CoronaDetails_tb.Where(c =>  c.positiveResultDate.Value.Month <= now.Month && 
                //c.positiveResultDate.Value.Month >= now.Month
                //).OrderBy(c => c.positiveResultDate);
                //return resulte.ToList().Count;

                //DateTime targetDate = new DateTime(2022, 5, 9);
                //var results = from c in db.CoronaDetails_tb
                //              where c.positiveResultDate <= targetDate && c.recoveryDate >= targetDate
                //              group c by c.positiveResultDate into g
                //              select new { Date = g.Key, Patients = g.Select(p => p.PersonId) };
                //return results.ToList();

                var resulte = db.CoronaDetails_tb.Where(c => c.positiveResultDate.HasValue &&
                         c.positiveResultDate.Value.Year == DateTime.Now.Year &&
                         c.positiveResultDate.Value.Month == DateTime.Now.Month &&
                         c.positiveResultDate.Value.Day <= 10);
                return resulte.ToList();
            }
        }

        // POST: api/Statistics
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Statistics/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Statistics/5
        public void Delete(int id)
        {
        }
    }
}
