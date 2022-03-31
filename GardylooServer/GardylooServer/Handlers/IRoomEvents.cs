using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public interface IRoomEvents<T> where T : class
	{
		public T RoomData { get; }
		public string RoomName { get; }
		public T AddRoom(string name);
		public T UpdateRoom(T settings);
		public T UpdateSettings(GameSettings settings);

		public GameStatusEnum ChangeState(GameStatusEnum state);
		public void AddStateListener(Func<string> state);
		public Player AddPlayer(string name);
		public void AddPlayerListener(Func<string, string> player);
	}
}
