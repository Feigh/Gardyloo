using Newtonsoft.Json;
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
		gamesetup, // Rummet har skapats och spelare välejr setting
		gameinitalizing, // Rummet förbered
		waitingtostart, // spelet startas spelare kan koppla upp sig
		gamestart, // spelet förbereder en omgång
		leaderprompt, // ledaren får se sin prompt
		playeranswere, // spelare väljer sigg spel utifrån prompt
		leaderanswere, // ledaren får välja ett svar från spelarna
		gamepoint, // spelaren får poäng
		gamevictory, // en spelare har vunnit
		gamefinish // spelet stänger av
	}

	public class Room
	{
		public Guid id;
		public string Name;
		public GameSettings Settings { get; set; }
		public GameStatusEnum state;
		public IEnumerable<Player> PlayerList;

		public Room(string name, GameSettings settings)
		{
			this.id = Guid.NewGuid();
			this.Name = name;
			this.Settings = settings;
			this.state = GameStatusEnum.gamesetup;
			this.PlayerList = new List<Player>();
		}
		public Room(string name)
		{
			this.id = Guid.NewGuid();
			this.Name = name;
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

	public class GameTag
	{
		public Guid id;
		public string text;

	}

	public class GameSettings
	{
		public Guid id { get; set; }
		public int GoalPoint { get; set; }
		public int MaxPlayers { get; set; }
		public int MinPlayers { get; set; }
		public double TimeLimit { get; set; }
		public IList<GameTagsObject> SelectedTags { get; set; }
		public IList<GameTagsObject> ExcludedTags { get; set; }

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
