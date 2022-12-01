using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
	public class GameData
	{
		private Guid _id;
		private IList<TurnData> _turnList;

		public GameData(Guid id, IList<TurnData> turnList)
		{
			_id = id;
			_turnList = turnList;
		}

		public Guid Id { get => _id; set => _id = value; }
		public IList<TurnData> TurnList { get => _turnList; set => _turnList = value; }

	}

	public class TurnData
	{
		private Guid _id;
		private IList<Prompt> _promptList;
		private IList<PlayerAnswere> _playerAnswereList;

		public TurnData(Guid id, IList<Prompt> promptList, IList<PlayerAnswere> playerAnswereList)
		{
			_id = id;
			_promptList = promptList;
			_playerAnswereList = playerAnswereList;
		}

		public Guid Id { get => _id; set => _id = value; }
		public IList<Prompt> PromptList { get => _promptList; set => _promptList = value; }
		public IList<PlayerAnswere> PlayerAnswereList { get => _playerAnswereList; set => _playerAnswereList = value; }

	}

	public class Prompt
	{
		private Guid _id;
		private string _text;
		private Guid _owner;
		private bool _selected;

		public Prompt(Guid id, string text, Guid owner, bool selected)
		{
			_id = id;
			_text = text;
			_owner = owner;
			_selected = selected;
		}

		public Guid Id { get => _id; set => _id = value; }
		public string Text { get => _text; set => _text = value; }
		public Guid Owner { get => _owner; set => _owner = value; }
		public bool Selected { get => _selected; set => _selected = value; }
	}
	public class Answere
	{
		private Guid _id;
		private string _text;
		private Guid _owner;
		private bool _selected;

		public Answere(Guid id, string text, Guid owner, bool selected)
		{
			_id = id;
			_text = text;
			_owner = owner;
			_selected = selected;
		}

		public Guid Id { get => _id; set => _id = value; }
		public string Text { get => _text; set => _text = value; }
		public Guid Owner { get => _owner; set => _owner = value; }
		public bool Selected { get => _selected; set => _selected = value; }
	}
	public class PlayerAnswere
	{
		private Guid _id;
		private IList<Answere> _answereList;
		private Guid _owner;
		private bool _select;

		public PlayerAnswere(Guid id, IList<Answere> answereList, Guid owner, bool select)
		{
			_id = id;
			_answereList = answereList;
			_owner = owner;
			_select = select;
		}

		public Guid Id { get => _id; set => _id = value; }
		public IList<Answere> Answeres { get => _answereList; set => _answereList = value; }
		public Guid Owner { get => _owner; set => _owner = value; }
		public bool WinningSelected { get => _select; set => _select = value; }
	}

	// Tydlig fungerar JSon serializer bara på properties
	public class Player
	{
		private Guid _id;
		private string _name;
		private bool _leader;
		private bool _active;
		public Guid Id { get => _id; set => _id = value; }
		public string Name { get => _name; set => _name = value; }
		public bool Leader { get => _leader; set => _leader = value; }
		public bool Active { get => _active; set => _active = value; }

		public Player(string name, bool leader, bool active)
		{
			_id = Guid.NewGuid();
			_name = name;
			_leader = leader;
			_active = active;
		}
	}



	// Detta är svar från spelarna
	public class PlayerEvent
	{
		private Guid id;
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
