using GardylooServer.Controllers;
using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public interface IRoomHandler
	{
		public string RoomName { get;}
		public RoomEvent RoomEvent { get; }
		public RoomListener RoomListener { get; }

		public Room AddRoom(string name);
		public Room UpdateRoomSettings(Room settings);
		public Player AddPlayer(string name);
		public Player UpdatePlayer(Player player);
		public void RemovePlayer(string name);
		public void StartGame(string playerId);
		public void SetupNextGame();
		public void SetupNextTurn();
		public void SetupNextPrompt();
		public void SetupNextPlayerAnsweres();
		public void CheckStatus();
		public void DeclareWinner();
		public void EndGame(string playerId);
		public IList<Prompt> GetCurrentPromptList(string playerId);
		public IList<Prompt> GetTurnPromptList(string turnId, string playerId);
		public IList<Prompt> ReloadPrompt(string playerId);
		public Prompt SetActivePrompt(string promptId);
		public IList<Answere> GetCurrentAnswereList(string playerId);
		public IList<Answere> GetTurnAnswereList(string turnId, string playerId);
		public PlayerAnswere GetTurnPlayerAnswere(string turnId, string playerId);
		public IList<Answere> ReloadPlayerAnswere(string playerId);
		public IList<Answere> SetActiveAnsweres(IList<string> answereId);

	}
}
