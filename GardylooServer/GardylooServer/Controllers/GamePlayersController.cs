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

namespace GardylooServer.Controllers
{
	[EnableCors("_myAllowSpecificOrigins")]
	[Route("api/[controller]")]
	[ApiController]
	public class GamePlayersController : ControllerBase
	{
		private readonly ILogger<GameStateController> _logger;
		private readonly GameHandler _gameHandler;
		private readonly IHubContext<PlayersStateHub> _playerhub;

		public GamePlayersController(ILogger<GameStateController> logger, GameHandler gameHandler, IHubContext<PlayersStateHub> playerhub)
		{
			_logger = logger;
			_gameHandler = gameHandler;
			_playerhub = playerhub;
		}

		// GET: api/<StateController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				await _playerhub.Clients.All.SendAsync("GetPlayers", "meep");
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
