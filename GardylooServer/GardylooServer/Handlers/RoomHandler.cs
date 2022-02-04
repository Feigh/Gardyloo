using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class RoomHandler : IRoomHandler<Room>
	{
		private IList<Room> _roomhandler;

		public RoomHandler()
		{
			_roomhandler = new List<Room>();
		}

		public IList<Room> RoomList { get { return _roomhandler; } }

		public Room AddRoom(string name, ISettingsHandler settings)
		{
			throw new NotImplementedException();
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
