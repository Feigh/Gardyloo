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
		private readonly IDataReader<GameTagObject> _dataHandler;
		private readonly IMapper _mapper;

		public GameTagController(ILogger<GameTagController> logger, IDataReader<GameTagObject> dataHandler, IMapper mapper)
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
				return new JsonResult(_mapper.Map<List<GameTagObject>>(_dataHandler.GetAllItem()));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Geting All Tags");
			}
		}


		[HttpGet("tag")]
		public IActionResult Get(string tag)
		{
			try
			{
				return new JsonResult(_mapper.Map<GameTagObject>(_dataHandler.GetAllItem().Where(x => x.id==tag).FirstOrDefault()));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest("Failed Geting Specefic Tags");
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
