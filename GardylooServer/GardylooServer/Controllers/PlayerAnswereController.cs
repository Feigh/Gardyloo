using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GardylooServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerAnswereController : ControllerBase
	{
		private readonly ILogger<PlayerAnswereController> _logger;
		// GET: api/<PlayerAnswereController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<PlayerAnswereController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PlayerAnswereController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<PlayerAnswereController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PlayerAnswereController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
