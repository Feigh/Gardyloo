using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Entities
{
	public class GameEnteties
	{
	}

	public enum GameStatusEnum
	{
		gamesetup,
		gameinitalizing,
		waitingtostart,
		gamestart,
		leaderprompt,
		playeranswere,
		leaderanswere,
		gamepoint,
		gamevictory,
		gamefinish
	}

	public class Room
	{
		public Guid id;
		public Guid settingsId;
		public string Name;
		public string Settings;
		public GameStatusEnum state;
		public IEnumerable<Player> PlayerList;

		public Room(string name, string settings)
		{
			this.id = Guid.NewGuid();
			this.Name = name;
			this.Settings = settings;
			this.state = GameStatusEnum.gamesetup;
			this.PlayerList = new List<Player>();
		}
	}

	public class Player
	{
		public Guid id;
		public string name;
		public bool leader;

		public Player(string name, bool leader)
		{
			this.id = Guid.NewGuid();
			this.name = name;
			this.leader = leader;
		}
	}

	public class GameSettings
	{
		public Guid id;
		public int GoalPoint;
		public int MaxPlayers;
		public int MinPlayers;
		public double TimeLimit;
		public IList<GameTagsObject> SelectedTags;
		public IList<GameTagsObject> ExcludedTags;

		public GameSettings()
		{
			this.id = Guid.NewGuid();
			GoalPoint = 0;
			MaxPlayers = 0;
			MinPlayers = 0;
			TimeLimit = 0;
			SelectedTags = new List<GameTagsObject>();
			ExcludedTags = new List<GameTagsObject>();
		}
	}

}
