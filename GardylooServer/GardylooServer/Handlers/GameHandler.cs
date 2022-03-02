using GardylooServer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class GameHandler : IGameHandler
	{
		private readonly ILogger<GameHandler> _logger;
		private GameStatusEnum _state;
		public GameStatusEnum CurrentGameState { get; }
		public GameHandler(ILogger<GameHandler> logger)
		{
			_state = GameStatusEnum.gamesetup;
			_logger = logger;

		}

		public GameStatusEnum UpdateGameState(GameStatusEnum state)
		{
			try
			{
				_state = state;
				return _state;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				throw new Exception("Error Uppdatera State");
			}
		}
	}
}
