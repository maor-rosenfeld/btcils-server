using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace btcils_server.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("")]
        [HttpGet]
        public string Hello()
        {
            return "Hello world";
        }

        [Route("hi")]
        public IEnumerable<string> Get()
        {
            return new string[] { "sup", "bro" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
