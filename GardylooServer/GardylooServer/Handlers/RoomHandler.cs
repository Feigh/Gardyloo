using GardylooServer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class RoomHandler : IRoomHandler
	{
		private string _roomName;
		private RoomEvent _roomEvent;
		private RoomListener _roomListner;

		public RoomHandler(string roomName, GameSettings settings)
		{
			_roomEvent = new RoomEvent(roomName, settings);
			_roomListner = new RoomListener();
			_roomName = roomName;
		}

		public string RoomName { get => _roomName; } 

		public RoomEvent RoomEvent { get => _roomEvent; }

		public RoomListener RoomListener { get => _roomListner; }

		public Player AddPlayer(string name)
		{
			throw new NotImplementedException();
		}

		public Room AddRoom(string name)
		{
			throw new NotImplementedException();
		}

		public void CheckStatus()
		{
			throw new NotImplementedException();
		}

		public void DeclareWinner()
		{
			throw new NotImplementedException();
		}

		public void EndGame(string playerId)
		{
			throw new NotImplementedException();
		}

		public IList<Answere> GetCurrentAnswereList(string playerId)
		{
			throw new NotImplementedException();
		}

		public IList<Prompt> GetCurrentPromptList(string playerId)
		{
			throw new NotImplementedException();
		}

		public IList<Answere> GetTurnAnswereList(string turnId, string playerId)
		{
			throw new NotImplementedException();
		}

		public PlayerAnswere GetTurnPlayerAnswere(string turnId, string playerId)
		{
			throw new NotImplementedException();
		}

		public IList<Prompt> GetTurnPromptList(string turnId, string playerId)
		{
			throw new NotImplementedException();
		}

		public IList<Answere> ReloadPlayerAnswere(string playerId)
		{
			throw new NotImplementedException();
		}

		public IList<Prompt> ReloadPrompt(string playerId)
		{
			throw new NotImplementedException();
		}

		public void RemovePlayer(string name)
		{
			throw new NotImplementedException();
		}

		public IList<Answere> SetActiveAnsweres(IList<string> answereId)
		{
			throw new NotImplementedException();
		}

		public Prompt SetActivePrompt(string promptId)
		{
			throw new NotImplementedException();
		}

		public void SetupNextGame()
		{
			throw new NotImplementedException();
		}

		public void SetupNextPlayerAnsweres()
		{
			throw new NotImplementedException();
		}

		public void SetupNextPrompt()
		{
			throw new NotImplementedException();
		}

		public void SetupNextTurn()
		{
			throw new NotImplementedException();
		}

		public void StartGame(string playerId)
		{
			throw new NotImplementedException();
		}

		public Player UpdatePlayer(Player player)
		{
			throw new NotImplementedException();
		}

		public Room UpdateRoomSettings(Room settings)
		{
			throw new NotImplementedException();
		}
	}
}
