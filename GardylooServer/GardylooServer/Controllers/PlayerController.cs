using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardylooServer.Hubs;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GardylooServer.Controllers
{
	[EnableCors("_myAllowSpecificOrigins")]
	[Route("api/[controller]")]
	[ApiController]
	public class PlayerController : ControllerBase
	{
		private readonly ILogger<PlayerController> _logger;

		public PlayerController( ILogger<PlayerController> logger)
		{
			_logger = logger;
		}

		// GET: api/<PlayerController>
		//[EnableCors("CorsPolicy")]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}

		// GET api/<PlayerController>/5
		[HttpGet("{id}")]
		public string Get(string id)
		{
			return "value";
		}

		// POST api/<PlayerController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
			var stuff = 10;
		}

		// PUT api/<PlayerController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PlayerController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
