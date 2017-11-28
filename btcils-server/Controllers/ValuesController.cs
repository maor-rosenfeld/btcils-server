using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace btcils_server.Controllers
{
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("api/hi")]
        public IEnumerable<string> Get()
        {
            return new string[] { "sup", "bro" };
        }
    }
}
