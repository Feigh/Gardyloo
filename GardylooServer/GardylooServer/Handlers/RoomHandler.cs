using GardylooServer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class RoomHandler : IRoomHandler<Room>
	{
		private IList<Room> _roomhandler; 
		private readonly ILogger<RoomHandler> _logger;

		public RoomHandler(ILogger<RoomHandler> logger)
		{
			_roomhandler = new List<Room>();
			_logger = logger;
		}

		public IList<Room> RoomList { get { return _roomhandler; } }

		public Room AddRoom(string name, GameSettings settings)
		{
			try
			{
				_roomhandler.Add(new Room(name, settings));
				return _roomhandler.Last();
			}
			catch(Exception ex)
			{
				_logger.LogError("Adding New Room Failed : " + ex.Message);
				throw new Exception("Adding New Room Failed : " + ex.Message);
			}

		}

		public string GenerateRoomName()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Random rnd = new Random();
			return new string(Enumerable.Repeat(chars, 4)
					.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}
	}
}
