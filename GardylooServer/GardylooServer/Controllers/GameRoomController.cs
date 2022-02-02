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
	public class GameRoomController : ControllerBase
	{
		private readonly ILogger<GameRoomController> _logger;

		public GameRoomController(ILogger<GameRoomController> logger)
		{
			_logger = logger;
		}

		// GET api/<GameRoom>/5
		[HttpGet("{id}")]
		public string Get(string id)
		{
			return "value";
		}

		// POST api/<GameRoom>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<GameRoom>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<GameRoom>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
