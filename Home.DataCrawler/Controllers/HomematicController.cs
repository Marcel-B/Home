using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Home.DataCrawler.Code;
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
        public IActionResult SetStates(IEnumerable<RootObject> values)
        {
            var dc = _service.GetService<DataCruncher>();
            foreach (var v in values)
            {
				var tmp = new MeasurePoint
				{
					Guid = Guid.NewGuid().ToString(),
					ChannelId = v.@params[1].ToString(),
					Create = DateTimeOffset.Now,
					PointName = v.@params[2].ToString()
				};
				var kk = v.@params[3].ToString();
				try{
					if (double.TryParse(kk, out var oo))
                        tmp.PointValue = oo;
                    else if (bool.TryParse(kk, out var ii))
                        if (ii)
                            tmp.PointValue = 1;
                        else
                            tmp.PointValue = 0;
                    dc.SetData(tmp);
				}
				catch(Exception ex){
                    Console.WriteLine(ex.Message);
					return NotFound();
				}
            }
            return Ok();
        }
    }



    public class RootObject
    {
        public string methodName { get; set; }
        public List<object> @params { get; set; }
    }
}
