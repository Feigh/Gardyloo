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
		IRoomHandler<RoomEvent> _roomHandler;
		public GameStateHub(ILogger<GameStateHub> logger, IRoomHandler<RoomEvent> rhandler)
		{
			_logger = logger;
			_roomHandler = rhandler;
		}
		public async Task GetState(string room)
		{
			// Detta är anropet från  klienten och room är det rum som settings skapat
			// då ham man room handler och lägg in listener som då lägger ett event i add
			var myRoom = _roomHandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
			if(myRoom!=null)
				myRoom.AddStateListener(() => SendState(room));
		}

		public string SendState(string room)
		{
			var myRoom = _roomHandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
			//await Clients.All.SendAsync("GetRoomState", myRoom.RoomData.state.ToString()); // await denna anropar mottagaren. men vi behövr inte fått nått svar så man bara fortsätter

			if (myRoom.RoomData.state == GameStatusEnum.gamefinish)
			{
				//await Clients.Caller.SendAsync("Finish");
			}
			else
			{
				myRoom.AddStateListener(() => SendState(room));
			}
			return "";
		}

		public override async Task OnConnectedAsync()
		{
			var connectionId = Context.ConnectionId;// anroparens id
			await Groups.AddToGroupAsync(connectionId, "testgroup");

		}
	}


}
