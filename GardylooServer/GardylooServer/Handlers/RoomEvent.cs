using GardylooServer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class RoomEvent : IRoomEvents<Room>
	{
		private Room _room;
		private readonly string _roomname;
		private Func<string> _stateEvent;

		public Room RoomData { get { return _room; } }
		public string RoomName { get { return _room.Name; } }

		public RoomEvent()
		{
		}
		public RoomEvent(string name)
		{
			_room = new Room(name);
		}

		public RoomEvent(string name, GameSettings settings)
		{
			try
			{
				_room = new Room(name, settings);
			}
			catch (Exception ex)
			{
				throw new Exception("Adding New Room Failed : " + ex.Message);
			}
		}

		public Room AddRoom(string name, GameSettings settings)
		{
			try
			{
				_room = new Room(name, settings);
				return _room;
			}
			catch (Exception ex)
			{
				throw new Exception("Adding New Room Failed : " + ex.Message);
			}
		}

		public GameStatusEnum ChangeState(GameStatusEnum state)
		{
			try
			{
				_room.state = state;

				_stateEvent.Invoke();

				return _room.state;
			}
			catch (Exception ex)
			{
				throw new Exception("Changeing State Failed : " + ex.Message);
			}
		}

		public void AddStateListener(Func<string> function)
		{
			try
			{
				_stateEvent += function;

			}
			catch (Exception ex)
			{
				throw new Exception("Getting Room State Failed : " + ex.Message);
			}
		}

		public Player AddPlayer(string name)
		{
			throw new NotImplementedException();
		}

		public void AddPlayerListener(Func<string, string> player)
		{
			throw new NotImplementedException();
		}

		public Room AddRoom(string name)
		{
			try
			{
				_room = new Room(name);
				return _room;
			}
			catch (Exception ex)
			{
				throw new Exception("Adding New Room Failed : " + ex.Message);
			}
		}

		public Room UpdateSettings(GameSettings settings)
		{
			try
			{
				_room.Settings = settings;
				return _room;
			}
			catch (Exception ex)
			{
				throw new Exception("Uppdating Room Failed : " + ex.Message);
			}
		}

		public Room UpdateRoom(Room settings)
		{
			try
			{
				if(settings.Name!=RoomName)
					throw new ArgumentNullException("Update Room Failed : Room parameter different from room to change");
				_room.Settings = settings.Settings;
				ChangeState(GameStatusEnum.waitingtostart);

				return _room;
			}
			catch (ArgumentNullException aex)
			{
				throw new ArgumentNullException("Update Room Failed : " + aex.Message);
			}
			catch (Exception ex)
			{
				throw new Exception("Update Failed : " + ex.Message);
			}
		}
	}
}
