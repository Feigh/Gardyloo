using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public interface IRoomHandler<T> where T : class
	{
		public IList<T> RoomList { get; }

		public string GenerateRoomName();

		public T AddRoom(string name, GameSettings settings);
		public T UpdateRoom(Room room);
		public T DeleteRoom(string name);
	}
}
