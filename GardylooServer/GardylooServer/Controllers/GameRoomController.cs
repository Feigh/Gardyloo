using GardylooServer.Entities;
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
	public class GameRoomController : ControllerBase
	{
		private readonly ILogger<GameRoomController> _logger;
		private readonly IRoomHandler<Room> _roomHandler;
		private readonly ISettingsHandler _settingsHandler;

		public GameRoomController(ILogger<GameRoomController> logger, IRoomHandler<Room> handler, ISettingsHandler shandler)
		{
			_logger = logger;
			_roomHandler = handler;
			_settingsHandler = shandler;
		}

		[HttpGet()]
		public IActionResult Get()
		{
			try
			{
				// Jag vet att jag ska skapa ett nytt rum
				// Jag anropar settingshandler skapa nyt setting och får ett settingsobject tillbka
				// detta lägger jag in i roomhandler som nytt rum
				// jag får tillbaka ett rum och jag skickar tillbaka ID eller nått mer
				return BadRequest("Failed Creating a new Room");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Creating a new Room");
			}
		}

		// GET api/<GameRoom>/5
		[HttpGet("{roomname}")]
		public IActionResult Get(string roomname)
		{
			try
			{
				return BadRequest($"Failed Finding the Requested Room {roomname}");
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest($"Failed Finding the Requested Room {roomname}");
			}
		}

		// POST api/<GameRoom>
		[HttpPost]
		public IActionResult Post([FromBody] string value)
		{
			try
			{
				return BadRequest($"Failed Updating Room {value}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest($"Failed Updating Room {value}");
			}
		}
	}
}
