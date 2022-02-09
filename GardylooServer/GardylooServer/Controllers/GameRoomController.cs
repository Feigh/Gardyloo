using AutoMapper;
using GardylooServer.Entities;
using GardylooServer.Handlers;
using GardylooServer.Repository;
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
		private readonly IDataReader<GameSettings> _dataHandler;
		private readonly IMapper _mapper;

		public GameRoomController(ILogger<GameRoomController> logger, IRoomHandler<Room> handler, IDataReader<GameSettings> settings, IMapper mapper)
		{
			_logger = logger;
			_roomHandler = handler;
			_dataHandler = settings;
			_mapper = mapper;
		}

		[HttpGet()]
		public IActionResult Get()
		{
			try
			{
				return new JsonResult(_roomHandler.AddRoom(_roomHandler.GenerateRoomName(), _dataHandler.GetItem("")));
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
				return new JsonResult(_roomHandler.RoomList.Where(x => x.Name==roomname).FirstOrDefault());
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
