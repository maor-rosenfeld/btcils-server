using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace btcils_server.Controllers
{
    [EnableCors("http://www.maor.io", "*", "*")]
    public class ValuesController : ApiController
    {
        [Route("")]
        [HttpGet]
        public string Hello()
        {
            return "Hello world";
        }

        private static object _lockMe = new Object();
        private static DateTime _date;
        private static Dictionary<string,string> _info = new Dictionary<string, string>();

        [Route("get-prices")]
        [HttpGet]
        public Dictionary<string, string> GetPrices()
        {
            if (DateTime.Now - _date < TimeSpan.FromSeconds(10))
                return _info;

            lock (_lockMe)
            {
                if (DateTime.Now - _date < TimeSpan.FromSeconds(10))
                    return _info;

                var client = new WebClient();
                _info["preev"] = client.DownloadString("http://preev.com/pulse/units:btc+ils/sources:bitfinex+bitstamp+btce");
                try
                {
                    _info["btc"] = client.DownloadString("https://bit2c.co.il/Exchanges/BtcNis/Ticker.json");
                }
                catch (Exception)
                {
                    
                }

                try
                {
                    _info["bog"] = client.DownloadString("https://www.bitsofgold.co.il/api/btc");
                }
                catch (Exception)
                {

                }
                _date = DateTime.Now;
                return _info;
            }
        }

    }
}
