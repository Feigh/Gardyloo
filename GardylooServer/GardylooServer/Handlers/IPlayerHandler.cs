using GardylooServer.Entities;
using System;
using System.Collections.Generic;

namespace GardylooServer.Handlers
{
	public interface IPlayerHandler<T> where T : class
	{
		public IList<T> PlayerList { get; }

		public T AddRoom(string name, GameSettings settings);
		//public T UpdateRoom(Room room);
		public T DeleteRoom(string name);
	}
}
