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
		private readonly IRoomHandler<RoomEvent> _roomHandler;
		private readonly IDataReader<GameSettingsObject> _dataHandler;
		private readonly IMapper _mapper;

		public GameRoomController(ILogger<GameRoomController> logger, IRoomHandler<RoomEvent> handler, IDataReader<GameSettingsObject> settings, IMapper mapper)
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
				return new JsonResult(_mapper.Map<GameRoomObject>(_roomHandler.AddRoom(_roomHandler.GenerateRoomName(), _mapper.Map<GameSettings>(_dataHandler.GetItem(""))).RoomData));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Creating a new Room");
			}
		}

		// GET api/<GameRoom>/5
		[HttpGet("room")]
		public IActionResult Get(string room)
		{
			try
			{
				var roomF = _roomHandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
				if (roomF == null)
					return BadRequest($"Failed Finding the Requested Room {room}");

				return new JsonResult(_mapper.Map<GameRoomObject>(roomF.RoomData));
		
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest($"Failed Finding the Requested Room {room}");
			}
		}

		// POST api/<GameRoom>
		[HttpPost]
		public IActionResult Post([FromBody] GameRoomObject room)
		{
			try
			{
				var stuff = _mapper.Map<Room>(room);
				return new JsonResult(_mapper.Map<GameRoomObject>(_roomHandler.RoomList
					.Where(x => x.RoomName==room.Name).FirstOrDefault()
					.UpdateRoom(_mapper.Map<Room>(room))));
				//return new JsonResult(_mapper.Map<GameRoomObject>(_roomHandler.UpdateRoom(_mapper.Map<Room>(room))));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest($"Failed Updating Room {room.Name}");
			}
		}
	}
}
