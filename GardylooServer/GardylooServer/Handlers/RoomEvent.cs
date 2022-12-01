using GardylooServer.Entities;
using System.Collections.Generic;

namespace GardylooServer.Handlers
{
	public class RoomEvent
	{
		private Room _room;
		private IList<GameData> _gameData;

		public RoomEvent(string name, GameSettings setting)
		{
			_room = new Room(name, setting);
		}

		public Room RoomData { get { return _room; } }

		public IList<GameData> GameData { get => _gameData; set => _gameData = value; }
	}
}
