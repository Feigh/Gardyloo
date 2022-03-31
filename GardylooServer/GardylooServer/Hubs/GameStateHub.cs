﻿using GardylooServer.Entities;
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

			try
			{
				var myRoom = _roomHandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
				if (myRoom != null)
				{
					await Clients.All.SendAsync("GetRoomState", myRoom.RoomData.state.ToString()); // skicka status till klienten
					if (myRoom.RoomData.state != GameStatusEnum.gamefinish)
						myRoom.AddStateListener(() => UpdateClient(room));// så länge status inte är slut så länka till handler att köra denna när status ändras
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in GetState : {ex.Message}");
			}
		}

		public async Task UpdateClient(string room)
		{

			try
			{
				var myRoom = _roomHandler.RoomList.Where(x => x.RoomName == room).FirstOrDefault();
				if (myRoom != null)
				{
					//var context = Microsoft.AspNetCore.SignalR.

					if (myRoom.RoomData.state != GameStatusEnum.gamefinish)
					myRoom.AddStateListener(() => UpdateClient(room));// så länge status inte är slut så länka till handler att köra denna när status ändras
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in GetState : {ex.Message}");
			}
		}

		public override async Task OnConnectedAsync()
		{
			var connectionId = Context.ConnectionId;// anroparens id
			await Groups.AddToGroupAsync(connectionId, "testgroup");

		}
	}


}
