using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Prometheus;

namespace PrometheusSampleApp.Controllers
{
    public class MetricsController : Controller
    {
        // GET metrics/prometheus
        public ActionResult Prometheus()
        {
            using (var stream = new MemoryStream(100000))
            using (var reader = new StreamReader(stream))
            {
                var task = Metrics.DefaultRegistry.CollectAndExportAsTextAsync(stream);
                task.GetAwaiter().GetResult();
                stream.Seek(0, SeekOrigin.Begin);
                var bodyText = String.Format("<pre>{0}</pre>", reader.ReadToEnd());
                return Content(bodyText);
            }
        }
    }
}
