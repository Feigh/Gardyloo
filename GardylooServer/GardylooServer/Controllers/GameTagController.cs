using AutoMapper;
using GardylooServer.Entities;
using GardylooServer.Repository;
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
		private readonly IDataReader<GameTagsObject> _dataHandler;
		private readonly IMapper _mapper;

		public GameTagController(ILogger<GameTagController> logger, IDataReader<GameTagsObject> dataHandler, IMapper mapper)
		{
			_logger = logger;
			_dataHandler = dataHandler;
			_mapper = mapper;
		}

		[HttpGet()]
		public IActionResult Get()
		{
			try
			{
				return new JsonResult(_mapper.Map<IList<GameTag>>(_dataHandler.GetAllItem().ToList()));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Creating a new Room");
			}
		}


		[HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			try
			{
				return new JsonResult(_mapper.Map<GameTag>(_dataHandler.GetAllItem().Where(x => x.Id==id).FirstOrDefault()));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Creating a new Room");
			}
		}

		// POST api/<RoomSettingsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
			throw new NotImplementedException();
		}


		// DELETE api/<RoomSettingsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
