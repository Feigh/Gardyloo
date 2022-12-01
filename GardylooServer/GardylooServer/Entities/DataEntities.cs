using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Entities
{

	public class GameSoundObject
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string UnderTitle { get; set; }
		public string FileName { get; set; }
		public string Path { get; set; }
		public string Creator { get; set; }
		public IEnumerable<GameTagObject> Tags { get; set; }
	}

	public class GamePrompsObject
	{
		public string Id { get; set; }
		public string Text { get; set; }
		public string FilePath { get; set; }
		public string FileName { get; set; }
		public string Creator { get; set; }
		public IEnumerable<GameTagObject> Tags { get; set; }
	}


	public class GameTagObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("name")]
		public string Text { get; set; }
	}

	public class GameSettingsObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("goalpoint")]
		public int GoalPoint { get; set; }
		[JsonProperty("maxplayers")]
		public int MaxPlayers { get; set; }
		[JsonProperty("minplayers")]
		public int MinPlayers { get; set; }
		[JsonProperty("timelimit")]
		public double TimeLimit { get; set; }
		[JsonProperty("selectedtags")]
		public IList<GameTagObject> SelectedTags { get; set; }
		[JsonProperty("excludedtags")]
		public IList<GameTagObject> ExcludedTags { get; set; }

	}

	public class GameRoomObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("settings")]
		public GameSettingsObject Settings { get; set; }
		[JsonProperty("gamestatus")]
		public string GameStatus { get; set; }
		[JsonProperty("playerlist")]
		public List<PlayerObject> PlayerList { get; set; }
	}


	public class PlayerObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("leader")]
		public bool Leader { get; set; }

	}
}
