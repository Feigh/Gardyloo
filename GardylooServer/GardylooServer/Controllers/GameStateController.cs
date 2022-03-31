using GardylooServer.Handlers;
using GardylooServer.Hubs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GardylooServer.Controllers
{
	[EnableCors("_myAllowSpecificOrigins")]
	[Route("api/[controller]")]
	[ApiController]
	public class GameStateController : ControllerBase
	{
		private readonly ILogger<GameStateController> _logger;
		private readonly GameHandler _gameHandler;
		private readonly IHubContext<GameStateHub> _statehub;

		public GameStateController(ILogger<GameStateController> logger, GameHandler gameHandler, IHubContext<GameStateHub> statehub)
		{
			_logger = logger;
			_gameHandler = gameHandler;
			_statehub = statehub;
		}

		// GET: api/<StateController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				await _statehub.Clients.All.SendAsync("GetState", "meep");
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Connecting to GameSettings Websocket service");
			}
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
