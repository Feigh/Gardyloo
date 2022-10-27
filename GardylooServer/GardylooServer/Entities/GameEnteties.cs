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
		public IList<Player> PlayerList;

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

	// Tydlig fungerar JSon serializer bara på properties
	public class Player
	{
		private Guid id;
		private string name;
		private bool leader;

		public Guid Id { get => id; set => id = value; }
		public string Name { get => name; set => name = value; }
		public bool Leader { get => leader; set => leader = value; }

		public Player(string name, bool leader)
		{
			this.Id = Guid.NewGuid();
			this.Name = name;
			this.Leader = leader;
		}
	}

	public class GameTag
	{
		public Guid id;
		public string text;

		public GameTag()
		{
			this.id = Guid.NewGuid();
			this.text = "";
		}
	}

	public class GameSettings
	{
		public Guid id { get; set; }
		public int GoalPoint { get; set; }
		public int MaxPlayers { get; set; }
		public int MinPlayers { get; set; }
		public double TimeLimit { get; set; }
		public IList<GameTagObject> SelectedTags { get; set; }
		public IList<GameTagObject> ExcludedTags { get; set; }
		// lägg till att man kan välja olika state av olika state av val, om nån vinner en prompt så blir de ledare eller så slumpas det etc

		public GameSettings()
		{
			this.id = Guid.NewGuid();
			GoalPoint = 0;
			MaxPlayers = 0;
			MinPlayers = 0;
			TimeLimit = 0;
			SelectedTags = new List<GameTagObject>();
			ExcludedTags = new List<GameTagObject>();
		}
	}

}
