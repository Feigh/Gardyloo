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
	public class PlayersStateHub : Hub
	{
		private readonly ILogger<PlayersStateHub> _logger;
		private readonly IRoomHandler<Room> _roomhandler;
		public PlayersStateHub(ILogger<PlayersStateHub> logger, IRoomHandler<Room> rhandler)
		{
			_logger = logger;
			_roomhandler = rhandler;
		}
		public async Task SendPlayer(string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", message);
		}

		//public override async Task OnConnectedAsync()
		//{
		//	var connectionId = Context.ConnectionId;// anroparens id
		//	await Groups.AddToGroupAsync(connectionId, "testgroup");

		//}
	}
}
