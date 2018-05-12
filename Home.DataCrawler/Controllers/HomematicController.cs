using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Home.DataCrawler.Data;
using Home.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Home.DataCrawler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomematicController : Controller
    {
        readonly IServiceProvider _service;

        public HomematicController(IServiceProvider service)
        {
            _service = service;
        }

        [HttpGet("ll")]
        public IActionResult GetAction()
        {
            var db = _service.GetService<ValueContext>();
            var ll = db.MeasurePoints;
            foreach (var l in ll)
            {
                Console.WriteLine(l.PointName);
            }
            return Ok();
        }
        
        [HttpPost("setstates")]
        public async Task<IActionResult> SetStates(IEnumerable<RootObject> values)
        {
            var h = new HashSet<string>{
                "OEQ1668708:1", // WandThermostat
                "NEQ1297587:1", // BRIGHTNESS
                "OEQ0571647:1", // STATE SteckdoseTv
                "OEQ0222798:1", // Fenster BadHinten
                "OEQ0707446:1", // Fenster RechtsSchlafzimmer
                "OEQ0222677:1", // TerrasseRechts
                "OEQ0226938:1", // TerrasseLinks
                "NEQ1774153:4", // BadHinten Temperatur
                "NEQ1778676:4", // HeizungWohnen
            };
            var n = new HashSet<string>{
                "TEMPERATURE",
                "BRIGHTNESS",
                "HUMIDITY",
                "STATE",
                "ACTUAL_TEMPERATURE",
            };


            //var dict = new Dictionary<Tuple<string, string>, MeasurePoint>();
            //dict[new Tuple<string, string>("OEQ0571647:1", "STATE")] = new MeasurePoint { PointName = "SteckdoseTV" };
            //dict[new Tuple<string, string>("OEQ1668708:1", "HUMIDITY")] = new MeasurePoint { PointName = "Luftfeuchte" };
            //dict[new Tuple<string, string>("OEQ1668708:1", "TEMPERATURE")] = new MeasurePoint { PointName = "Temperatur" };

            var p = new List<MeasurePoint>();
            foreach (var v in values)
            {
                var id = v.@params[1].ToString();
                var name = v.@params[2].ToString();
                if (!h.Contains(id)) continue;
                if (!n.Contains(name)) continue;
                
                var tmp = new MeasurePoint();
                tmp.Guid = Guid.NewGuid().ToString();
                tmp.ChannelId = v.@params[1].ToString();
                tmp.Create = DateTimeOffset.Now;
                tmp.PointName = v.@params[2].ToString();
                var kk = v.@params[3].ToString();
                if (double.TryParse(kk, out var oo))
                    tmp.PointValue = oo;
                else if (bool.TryParse(kk, out var ii))
                    if (ii)
                        tmp.PointValue = 1;
                    else
                        tmp.PointValue = 0;

                p.Add(tmp);
                Console.WriteLine($"# Method Name = {v.methodName}");
                Console.WriteLine($"# Job Name    = {v.@params[0]}");
                Console.WriteLine($"# Channel Id  = {v.@params[1]}");
                Console.WriteLine($"# Point Name  = {v.@params[2]}");
                Console.WriteLine($"# Point Value = {v.@params[3]}");
                Console.WriteLine("##########################################");


            }
            try
            {

                var db = _service.GetService<ValueContext>();
                await db.MeasurePoints.AddRangeAsync(p).ConfigureAwait(false);
                await db.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
    }



    public class RootObject
    {
        public string methodName { get; set; }
        public List<object> @params { get; set; }
    }
}
