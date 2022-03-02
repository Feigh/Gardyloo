using GardylooServer.Entities;
using GardylooServer.Handlers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Hubs
{
	public class GameStateHub : Hub
	{
		private readonly ILogger<GameStateHub> _logger;
		private readonly IGameHandler _gamehandler;
		public GameStateHub(ILogger<GameStateHub> logger, IGameHandler ghandler)
		{
			_logger = logger;
			_gamehandler = ghandler;
		}
		public async Task GetState(int state)
		{
			do
			{
				await Clients.Caller.SendAsync("GetRoomState", _gamehandler.CurrentGameState.ToString());
			} while (_gamehandler.CurrentGameState != GameStatusEnum.gamefinish);
			await Clients.Caller.SendAsync("Finish");
		}

		public override async Task OnConnectedAsync()
		{
			var connectionId = Context.ConnectionId;// anroparens id
			await Groups.AddToGroupAsync(connectionId, "testgroup");

		}
	}


}
