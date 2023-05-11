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
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<object> Get()
        {
            return DB.allPersones();
        }

        // GET: api/Person/5
        public Person Get(string id)
        {
            return DB.GetPerson(id);
        }

        // POST: api/Person
        public void Post([FromBody] Person_tb p)
        {
            DB.addPerson(p);
        }
       

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
