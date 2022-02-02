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
	public class GameSoundController : ControllerBase
	{
		private readonly ILogger<GameSoundController> _logger;
		// GET: api/<GameSoundController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<GameSoundController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<GameSoundController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<GameSoundController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<GameSoundController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
