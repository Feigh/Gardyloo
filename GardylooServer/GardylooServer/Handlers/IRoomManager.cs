using GardylooServer.Entities;
using System.Collections.Generic;

namespace GardylooServer.Handlers
{
	public interface IRoomManager
	{
		public IList<RoomHandler> RoomList { get; }

		public string GenerateRoomName();

		public RoomHandler AddRoom(string name, GameSettings settings);
		//public T UpdateRoom(Room room);
		public bool DeleteRoom(string name);
	}
}
