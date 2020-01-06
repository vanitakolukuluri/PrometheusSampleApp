using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prometheus;

namespace PrometheusSampleApp.Controllers
{
    public class ValuesController : ApiController
    {

        private static readonly Counter TickTock =
        Metrics.CreateCounter("sampleapp_ticks_total", "Just keeps on ticking");

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            TickTock.Inc();
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
