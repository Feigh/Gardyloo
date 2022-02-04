using GardylooServer.Handlers;
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
	public class GameStateController : ControllerBase
	{
		private readonly ILogger<GameStateController> _logger;
		private readonly GameHandler _gameHandler;

		public GameStateController(ILogger<GameStateController> logger, GameHandler gameHandler)
		{
			_logger = logger;
			_gameHandler = gameHandler;
		}

		// GET: api/<StateController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "initializing", "waiting" };
		}

		// GET api/<StateController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "initializing";
		}

		// POST api/<StateController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

	}
}
