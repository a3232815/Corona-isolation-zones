using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using שרת_שנה_ג.ef;
using שרת_שנה_ג.Models;

namespace שרת_שנה_ג.Controllers
{
    public class CoronaDetailController : ApiController
    {
        // GET: api/CoronaDetail
        public List<CoronaDetails> Get()
        {
            return DB.allCoronaDetails();
        }

        // GET: api/CoronaDetail/5
        public CoronaDetails Get(int id)
        {
            return DB.GetCoronaDetails(id);
        }

        // POST: api/CoronaDetail
        public void Post([FromBody]CoronaDetails_tb c)
        {
            DB.addCoronaDetails(c);
        }

        // PUT: api/CoronaDetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CoronaDetail/5
        public void Delete(int id)
        {
        }
    }
}
