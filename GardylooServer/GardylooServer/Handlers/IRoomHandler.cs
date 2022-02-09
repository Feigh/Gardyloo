using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public interface IRoomHandler<T>
	{
		public IList<T> RoomList { get; }

		public string GenerateRoomName();

		public T AddRoom(string name, GameSettings settings);
	}
}
