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
	public class RoomSettingsController : ControllerBase
	{
		private readonly ILogger<RoomSettingsController> _logger;
		// GET: api/<RoomSettingsController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<RoomSettingsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<RoomSettingsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
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
