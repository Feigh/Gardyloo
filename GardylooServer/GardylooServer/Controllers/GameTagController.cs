using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GameTagController : ControllerBase
	{
		private readonly ILogger<GameTagController> _logger;
		// GET: api/<RoomSettingsController>

		// GET api/<RoomSettingsController>/5
		[HttpGet("{id}")]
		public string Get(string id)
		{
			// få settings för valt rum
			return "value";
		}

		// POST api/<RoomSettingsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
			//uppdatera settings för valt rum 
		}

		// PUT api/<RoomSettingsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<RoomSettingsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
