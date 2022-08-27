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
		private readonly IRoomHandler<RoomEvent> _roomhandler;
		private readonly IHubContext<PlayersStateHub> _hubContext;
		public PlayersStateHub(ILogger<PlayersStateHub> logger, IRoomHandler<RoomEvent> rhandler, IHubContext<PlayersStateHub> hubContext)
		{
			_logger = logger;
			_roomhandler = rhandler;
			_hubContext = hubContext;
		}

		public async Task GetPlayers(string room)
		{
			try
			{
				var myRoom = _roomhandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
				if (myRoom != null)
				{
					await Clients.All.SendAsync("GetPlayers", myRoom.RoomData.PlayerList.ToString()); // skicka status till klienten
					if (myRoom.RoomData.state != GameStatusEnum.gamefinish)
						myRoom.AddStateListener(() => UpdateClient(room));// så länge status inte är slut så länka till handler att köra denna när status ändras
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in GetPlayers : {ex.Message}");
			}
		}
		public async Task UpdateClient(string room)
		{

			try
			{
				var myRoom = _roomhandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
				if (myRoom != null)
				{
					await _hubContext.Clients.All.SendAsync("GetPlayers", myRoom.RoomData.PlayerList.ToString());

					if (myRoom.RoomData.state == GameStatusEnum.gamefinish)
						myRoom.RemoveStateListener(() => UpdateClient(room));
					//myRoom.AddStateListener(() => UpdateClient(room));// så länge status inte är slut så länka till handler att köra denna när status ändras
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in GetPlayers : {ex.Message}");
			}
		}

		public override async Task OnConnectedAsync()
		{
			var connectionId = Context.ConnectionId;// anroparens id
			await Groups.AddToGroupAsync(connectionId, "testgroup");

		}
	}
}
