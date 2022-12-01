using GardylooServer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GardylooServer.Handlers
{
	public class RoomManager : IRoomManager
	{
		private IList<RoomHandler> _roomhandler;
		private readonly ILogger<RoomManager> _logger;

		public IList<RoomHandler> RoomList { get => _roomhandler; }

		public RoomManager(ILogger<RoomManager> logger)
		{
			_roomhandler = new List<RoomHandler>();
			_logger = logger;
		}

		public string GenerateRoomName()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random rnd = new Random();
			return new string(Enumerable.Repeat(chars, 4)
					.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}

		public RoomHandler AddRoom(string name, GameSettings settings)
		{
			try
			{
				_roomhandler.Add(new RoomHandler(name, settings));
				return _roomhandler.Last();
			}
			catch (Exception ex)
			{
				_logger.LogError("Adding New Room Failed : " + ex.Message);
				throw new Exception("Adding New Room Failed : " + ex.Message);
			}
		}

		public bool DeleteRoom(string name)
		{
			try
			{
				var room = _roomhandler.Where(x => x.RoomName==name).FirstOrDefault();
				_roomhandler.Remove(room);
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogError("Adding New Room Failed : " + ex.Message);
				throw new Exception("Adding New Room Failed : " + ex.Message);
			}

			return false;
		}
	}
}
