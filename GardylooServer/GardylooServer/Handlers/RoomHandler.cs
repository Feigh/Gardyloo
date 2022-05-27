using GardylooServer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class RoomHandler : IRoomHandler<RoomEvent>
	{
		private IList<RoomEvent> _roomhandler; 
		private readonly ILogger<RoomHandler> _logger;

		public RoomHandler(ILogger<RoomHandler> logger)
		{
			_roomhandler = new List<RoomEvent>();
			_logger = logger;
		}

		public IList<RoomEvent> RoomList { get { return _roomhandler; } }

		public RoomEvent AddRoom(string name, GameSettings settings)
		{
			try
			{
				_roomhandler.Add(new RoomEvent(name, settings));
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

		public Room DeleteRoom(string name)
		{
			throw new NotImplementedException();
		}


		RoomEvent IRoomHandler<RoomEvent>.DeleteRoom(string name)
		{
			throw new NotImplementedException();
		}
	}
}
