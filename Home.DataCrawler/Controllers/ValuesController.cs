using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home.DataCrawler.Data;
using Microsoft.AspNetCore.Mvc;
using Home.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Home.DataCrawler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
		private readonly IServiceProvider _service;

		public ValuesController(IServiceProvider service){
			_service = service;
		}

        // GET api/values
        [HttpGet]
		[ProducesResponseType(200)] 
		public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
			var db = _service.GetService<ValueContext>();
			return await db.Values.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
