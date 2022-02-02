using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class GameHandler
	{
		public GameHandler()
		{
			RoomList = new List<Room>();
		}

		public List<Room> RoomList { get; set; }

		public string GenerateRoomName()
		{
			throw new NotImplementedException();
		}

		public List<Room> AddNewRoom()
		{
			throw new NotImplementedException();
		}
	}
}
